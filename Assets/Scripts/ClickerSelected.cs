using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerSelected : MonoBehaviour
{
    [SerializeField] Clicker clicker;

    // Start is called before the first frame update
    void Start()
    {
        clicker.OnClickerClicked += Clicker_OnClickerClicked;
        clicker.OnClickerDeClicked += Clicker_OnClickerDeClicked;
        this.gameObject.SetActive(false);
    }

    private void Clicker_OnClickerDeClicked(object sender, EventArgs e)
    {
        this.gameObject.SetActive(false);
    }

    private void Clicker_OnClickerClicked(object sender, EventArgs e)
    {
        this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
