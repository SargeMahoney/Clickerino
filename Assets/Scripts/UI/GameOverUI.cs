using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI score; 
    [SerializeField] Button exitButton;

    [SerializeField] SaveScoreUI SaveScoreUI;

    // Start is called before the first frame update
    void Start()
    {
        ClickerGameManager.Instance.OnGameOver += Instance_OnGameOver;
        exitButton.onClick.AddListener(() => {   
            SaveScoreUI.Show();
        });

        Hide();
    }

    private void Instance_OnGameOver(object sender, System.EventArgs e)
    {
        Player.Instance.CheckFinalScore();
        score.text = Player.Instance.GetScore().ToString() + "p";
        Show();
    }

    // Update is called once per frame
    void Update()
    {

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
