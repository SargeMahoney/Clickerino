using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


/// <summary>
/// Sono presenti 2 clicker diversi
/// In un unico rettangolo standard di clicker messi random
/// </summary>
public class Level1 :  ILevel
{

    private string LevelName = "Level 1!";

    public string GetLevelName()
    {
        return LevelName;
    }


    /// <summary>
    /// Nel livello uno ci sono 20 clicker verdi e 20 rossi
    /// </summary>
    /// <param name="AllowedSceneClickersList"></param>
    /// <param name="totalPositions"></param>
    /// <returns></returns>
    public List<ClickerSO> CreateClickerList(List<ClickerSO> AllowedSceneClickersList, int totalPositions)
    {
        //verifica che le totalPositions sia un multiplo di 4
        if (totalPositions % 2 != 0)
        {
            Debug.LogError("totalPositions non è un multiplo di 4");
            return null;
        }

        var mySceneClickerList = new List<ClickerSO>();
        var halfCount = totalPositions / 2;

     

        //crea una lista di 10 clicker verdi per SceneClickersList
        for (int i = 0; i < halfCount; i++)
        {
            //seleziono il clickerSO verde
            var clickerSO = AllowedSceneClickersList.FirstOrDefault(x => x.ClickerType == ClickerType.Green);



            mySceneClickerList.Add(clickerSO);

        }

        //crea una lista di 10 clicker rossi per SceneClickersList
        for (int i = 0; i < halfCount; i++)
        {
            var clickerSO = AllowedSceneClickersList.FirstOrDefault(x => x.ClickerType == ClickerType.Red);


            mySceneClickerList.Add(clickerSO);

        }

        return mySceneClickerList;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
