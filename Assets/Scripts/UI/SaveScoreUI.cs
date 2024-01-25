using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveScoreUI : MonoBehaviour
{

    [SerializeField] private TMPro.TMP_InputField nameInputField;
    [SerializeField] private Button SaveButton;

    // Start is called before the first frame update
    void Start()
    {
     
        SaveButton.onClick.AddListener(() =>
        {
            if (string.IsNullOrWhiteSpace(nameInputField.text))
            {
                return;
            }
            TopScoresModel topScoresModel = new TopScoresModel();
            topScoresModel.Initialize(resetScore:false);

            ScoreModel score = new ScoreModel(0, nameInputField.text,(int) Player.Instance.GetScore());
            topScoresModel.InsertScore(score);
            Loader.loadSceneAsync(Loader.Scene.TopScores);
        });
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show()
    {

        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
