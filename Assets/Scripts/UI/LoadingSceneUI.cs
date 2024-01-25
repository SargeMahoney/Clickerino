using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadingSceneUI : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI loadingText;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        //ogni secondo aggiorna la scritta loadingText in modo che si incrementino dei puntini di sospensione
        loadingText.text = "Loading";
        for (int i = 0; i < (int)Time.time % 3; i++)
        {
            loadingText.text += ".";
        }

        //se ho messo 3 puntini di sospensione li tolgo e ricomincio
        if ((int)Time.time % 3 == 0)
        {
            loadingText.text = "Loading";
        }





        
    }
}
