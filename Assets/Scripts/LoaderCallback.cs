using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCallback : MonoBehaviour
{

    private bool isFirstUpdate = true;
    public float waitingToStartTimer = 3f;

    private void Update()
    {
        
            Loader.LoaderCallback();

        
    }

    private IEnumerator WaitFor3Seconds()
    {
        yield return new WaitForSeconds(3f);
        // Carica la scena qui
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

   
  
}
