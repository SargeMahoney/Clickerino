using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TopScoresUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI firstScore;
    [SerializeField] private TextMeshProUGUI secondScore;
    [SerializeField] private TextMeshProUGUI thirdScore;
    [SerializeField] private Button MainMenuButton;
    [SerializeField] private Button ResetScores;

    // Start is called before the first frame update 
    void Start()
    {
        TopScoresModel topScoresModel = new TopScoresModel();
        topScoresModel.Initialize(resetScore: false);

        //prendo i primi 3 score in ordine decrescente
        List<ScoreModel> scores = topScoresModel.GetScores().OrderByDescending(x => x.Score).Take(3).ToList();

        foreach (var item in scores)
        {
            if (item.Score == 0)
            {
                continue;
            }
            if (item.Id == 1)
            {
                firstScore.text = $"1. {scores[0].Name.ToString()} {scores[0].Score.ToString()}";
            }
            if (item.Id == 2)
            {
                secondScore.text = $"2. {scores[1].Name.ToString()} {scores[1].Score.ToString()}";
            }
            if (item.Id == 3)
            {
                thirdScore.text = $"3. {scores[2].Name.ToString()} {scores[2].Score.ToString()}";
            }
        }
               
     
        MainMenuButton.onClick.AddListener(() => {
            Time.timeScale = 1;
            Loader.loadSceneAsync(Loader.Scene.MainMenu); });

        ResetScores.onClick.AddListener(() =>
        {
            topScoresModel.ResetScores();
            Loader.loadSceneAsync(Loader.Scene.TopScores);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
