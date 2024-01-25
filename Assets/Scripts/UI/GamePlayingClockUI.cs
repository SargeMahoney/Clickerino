using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePlayingClockUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playingClockText;
    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start()
    {
        ClickerGameManager.Instance.OnStateChanged += Instance_OnStateChanged;
        this.gameObject.SetActive(false);

    }

    private void Instance_OnStateChanged(object sender, EventArgs e)
    {
        if (ClickerGameManager.Instance.IsGamePlaying())
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }


    // Update is called once per frame
    void Update()
    {
        playingClockText.text = Math.Round(ClickerGameManager.Instance.GetPlayingTimer(),1).ToString();
    }
}
