using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBlocker : MonoBehaviour
{

    private float movingGlass = 0f;
    private float maxTop = 4.5f;
    private float maxBottom = 4.5f;
    private float maxLeft = 5.5f;
    private float maxRight =5.5f;
    private float speed = 5f;

    private bool isInStartPosition = true;
    private bool isTopReached = false;
    private bool isBottomReached = false;
    private bool isLeftReached = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //sposta lentamente l'oggetto in alto pari alla sua stessa altezza
        if (isInStartPosition)
        {
            if (movingGlass <= maxTop)
            {
                transform.Translate(Vector3.up * Time.deltaTime * speed);
                movingGlass += Time.deltaTime * 1f;
                return;
            }
            else
            {
                isTopReached = true;
                isInStartPosition = false;
                movingGlass = 0;
            }

        }
     

        if (isTopReached && !isLeftReached && !isBottomReached )
        {
            if (movingGlass <= maxLeft)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                movingGlass += Time.deltaTime * 1f;
                return;
            }
            else
            {
                isLeftReached = true;
                movingGlass = 0;
            }
        }

        if (isTopReached && isLeftReached && !isBottomReached)
        {
            if (movingGlass <= maxBottom)
            {
                transform.Translate(Vector3.down * Time.deltaTime * speed);
                movingGlass += Time.deltaTime * 1f;
                return;
            }
            else
            {
                isBottomReached = true;
                movingGlass = 0;
            }
        }

        if (isTopReached && isLeftReached && isBottomReached)
        {
            if (movingGlass <= maxRight)
            {
                transform.Translate(Vector3.back * Time.deltaTime * speed);
                movingGlass += Time.deltaTime * 1f;
                return;
            }
            else
            {
                isTopReached = false;
                isLeftReached = false;
                isBottomReached = false;
                isInStartPosition = true;
                movingGlass = 0;
            }
        }
    
    }
}
