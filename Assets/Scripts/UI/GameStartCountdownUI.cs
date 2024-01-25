using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStartCountdownUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownText;
    [SerializeField] private TextMeshProUGUI levelNameText;

    // Start is called before the first frame update
    void Start()
    {
        ClickerGameManager.Instance.OnStateChanged += Instance_OnStateChanged;
  
    }

    private void Instance_OnStateChanged(object sender, EventArgs e)
    {
        if (ClickerGameManager.Instance.IsCountdownToStartActive())
        {
            levelNameText.text = ClickerGameManager.Instance.GetCurrentLevel().GetLevelName() + "!";
            Show();
        }
        else
        {
            Hide();
        }
    }

    // Update is called once per frame
    void Update()
    {
        countdownText.text = Mathf.Ceil(ClickerGameManager.Instance.GetCountdownToStartTimer()).ToString();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
