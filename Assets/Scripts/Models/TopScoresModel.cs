
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;


public class TopScoresModel
{

    private List<ScoreModel> scores = new List<ScoreModel>();


    //METODO DI INIZIALIZZAZIONE DELLA LISTA CHE CREA 10 SCOREMODEL CON ID PROGRESSIVO E SCORE A 0
    public void Initialize(bool resetScore)
    {
        if (!Directory.Exists(Application.persistentDataPath + "/TopScores/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/TopScores/");
        }

        if (resetScore)
        {
            scores = new List<ScoreModel>();
            for (var i = 1; i < 11; i++)
            {
                this.scores.Add(new ScoreModel(i, "", 0));
            }
            SaveScoresToJsonFile();

        }
        else
        {
            var result = LoadScoresFromJsonFile();
            //PROVO A VEDERE SE ESISTE UNA LISTA DI SCOREMODEL SALVATA IN PRECEDENZA
            if (!this.scores.Any())
            {
                for (var i = 1; i < 11; i++)
                {
                    this.scores.Add(new ScoreModel(i, "", 0));
                }
            }
        }
     


    }


    //METODO CHE INSERISCE UN SCOREMODEL ALLA LISTA, INSERENDOLO NELLA POSIZIONE GIUSTA IN BASE ALLO SCORE IN ORDINE DECRESCENTE
    public void InsertScore(ScoreModel score)
    {
        for (var i = 0; i < this.scores.Count; i++)
        {
            if (score.Score > this.scores[i].Score)
            {
                score.Id = i + 1;
                this.scores.Insert(i, score);

                //modifica gli id degli score successivi
                for (var j = i + 1; j < this.scores.Count; j++)
                {
                    this.scores[j].Id = j + 1;
                }

                break;
            }
        }
        //rimuovi l'ultimo score
        this.scores.RemoveAt(this.scores.Count - 1);

        SaveScoresToJsonFile();
    }


    public List<ScoreModel> GetScores()
    {
        return this.scores;
    }

    //METODO PER SALVARE LA LISTA DEI TOPSCORES


    public void SaveScoresToJsonFile()
    {
        var topScoreJson = new TopScoresJson();
        topScoreJson.scores = this.scores;
        //converti in un file json i top scores
        var json = JsonConvert.SerializeObject(topScoreJson,Formatting.Indented);

        //salva il file json
        File.WriteAllText(Application.persistentDataPath + "/TopScores/TopScores.json", json);
    }


    public void ResetScores()
    {
        this.scores = new List<ScoreModel>();
        Initialize(resetScore:true);
    }

    public bool LoadScoresFromJsonFile()
    {

        try
        {
            //controllo se il file esiste
            if (!File.Exists(Application.persistentDataPath + "/TopScores/TopScores.json"))
            {
                return false;
            }

            //carica il file json
            var json = File.ReadAllText(Application.persistentDataPath + "/TopScores/TopScores.json");
            //converti il file json in una lista di score model
            var myTopScores = JsonConvert.DeserializeObject<TopScoresJson>(json);

            if (myTopScores != null)
            {
                if (myTopScores.scores != null)
                {
                    this.scores = myTopScores.scores;
                }
                else
                {
                    this.scores = new List<ScoreModel>();
                }

            }
            else
            {
                this.scores = new List<ScoreModel>();
            }

            return true;
        }
        catch (System.Exception ex)
        {

            return false;
        }


    }
}


[Serializable]
public class TopScoresJson
{
    public List<ScoreModel> scores;
}