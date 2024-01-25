using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Score { get; set; }

    public ScoreModel(int id, string name, int score)
    {
        Id = id;
        Name = name;
        Score = score;
    }

    public ScoreModel()
    {

        Id = -1;
        Name = "";
        Score = 0;
    }
}
