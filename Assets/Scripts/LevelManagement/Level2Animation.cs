using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Animation : MonoBehaviour
{
    [SerializeField] private GameObject Container1;
    [SerializeField] private GameObject Container2;
    [SerializeField] private GameObject Container3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       var rotationSpeed = 35f;
        // Calculate the rotation amount based on time or any other dynamic factor
        float rotationAmount = Time.deltaTime * rotationSpeed;

    

        Container1.transform.RotateAround(Container1.transform.position, Vector3.forward, rotationAmount);
        Container2.transform.RotateAround(Container2.transform.position, Vector3.back, rotationAmount);
        Container3.transform.RotateAround(Container3.transform.position, Vector3.forward, rotationAmount);

    
   
        

    }
}
