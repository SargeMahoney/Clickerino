using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameFinishUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] Button continueButton;
    [SerializeField] Button exitButton;
    [SerializeField] SaveScoreUI SaveScoreUI;
    [SerializeField] LevelType nextLevel;

    // Start is called before the first frame update
    void Start()
    {
        ClickerGameManager.Instance.OnGameFinished += Instance_OnGameFinished; ;
        exitButton.onClick.AddListener(() => {
      
            SaveScoreUI.Show(); 
        });
        continueButton.onClick.AddListener(() => {
         
            Loader.loadSceneAsync(nextLevel);
        });
    
        Hide();
    }

    private void Instance_OnGameFinished(object sender, System.EventArgs e)
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
