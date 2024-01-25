using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Multiplier : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI multiplierText;
    // Start is called before the first frame update
    void Start()
    {
        Player.Instance.OnMoneyChanged += Instance_OnMoneyChanged;
        this.gameObject.SetActive(false);
        
    }

    private void Instance_OnMoneyChanged(object sender, Player.OnMoneyChangedEventArgs e)
    {
        if (e.Multiplier > 0)
        {
            this.gameObject.SetActive(true);
            multiplierText.text = "x" + e.Multiplier.ToString();
        }
        else
        {
            this.gameObject.SetActive(false);

        }
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
