using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePausedUI : MonoBehaviour
{

    [SerializeField] private Button resumeButton;
    [SerializeField] private Button menuButton;
    [SerializeField] SaveScoreUI SaveScoreUI;


    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    void Awake()
    {
  
   
    }
    // Start is called before the first frame update
    void Start()
    {
        resumeButton.onClick.AddListener(() =>
        {
            ClickerGameManager.Instance.TogglePauseGame();
        });
        menuButton.onClick.AddListener(() =>
        {
            SaveScoreUI.Show();
        });
        ClickerGameManager.Instance.OnGamePaused += GameManager_OnGamePaused;
        ClickerGameManager.Instance.OnGameUnpaused += GameManager_OnGameUnpaused;
        Hide();
  
    }

    public void Test()
    {
        Debug.Log("Test");
    }
    private void GameManager_OnGameUnpaused(object sender, EventArgs e)
    {
        Hide();
    }

    private void GameManager_OnGamePaused(object sender, EventArgs e)
    {
        Show();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
