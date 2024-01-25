using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{

    private ClickerSO clickerSO;

    public event EventHandler OnClickerClicked;
    public event EventHandler OnClickerDeClicked;


    public Clicker(ClickerSO clickerSO)
    {
        this.clickerSO = clickerSO;            
    }

    public void SetClickerSO(ClickerSO clickerSO)
    {
        this.clickerSO = clickerSO;

    }
   

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clicked()
    {
        //  Debug.Log("Clicked " + clickerSO.ClickerType.ToString());
        if (ClickerGameManager.Instance.IsGamePlaying())
        {
            OnClickerClicked?.Invoke(this, EventArgs.Empty);
        }
     

    }

    public void Deselected()
    {
        //Debug.Log("Deselected " + clickerSO.ClickerType.ToString());
        OnClickerDeClicked?.Invoke(this, EventArgs.Empty);
    }

    public ClickerSO GetClickerSO()
    {
        return clickerSO;
    }


 





}
