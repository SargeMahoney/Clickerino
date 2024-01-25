using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Sono presenti 3 clicker diversi
/// ci sono 3 gruppi di clicker con colori mischiati, i singoli gruppi sono  a forma di triangolo e ruotano su stessi durante la partita
/// </summary>
public class Level2 : ILevel
{

    private string levelName = "Level 2!";

    /// <summary>
    /// Nel livello due ci sono 20 clicker verdi, 20 rossi, 20 purple
    /// </summary>
    /// <param name="AllowedSceneClickersList"></param>
    /// <param name="totalPositions"></param>
    /// <returns></returns>
    public List<ClickerSO> CreateClickerList(List<ClickerSO> AllowedSceneClickersList, int totalPositions)
    {
        var mySceneClickerList = new List<ClickerSO>();

        //verifica che le totalPositions sia un multiplo di 3
        if (totalPositions % 3 != 0)
        {
            Debug.LogError("totalPositions non è un multiplo di 3");
            return null;
        }


        for (int i = 0; i < totalPositions/3; i++)
        {
            //seleziono il clickerSO verde
            var clickerSO = AllowedSceneClickersList.FirstOrDefault(x => x.ClickerType == ClickerType.Green);



            mySceneClickerList.Add(clickerSO);

        }

        for (int i = 0; i < totalPositions / 3; i++)
        {
            //seleziono il clickerSO verde
            var clickerSO = AllowedSceneClickersList.FirstOrDefault(x => x.ClickerType == ClickerType.Red);



            mySceneClickerList.Add(clickerSO);

        }

        for (int i = 0; i < totalPositions / 3; i++)
        {
            //seleziono il clickerSO verde
            var clickerSO = AllowedSceneClickersList.FirstOrDefault(x => x.ClickerType == ClickerType.Purple);



            mySceneClickerList.Add(clickerSO);

        }


        //verifica che il numero di clicker sia uguale a quello delle posizioni
        if (mySceneClickerList.Count != totalPositions)
        {
            Debug.Log("Error!");

        }



      

        return mySceneClickerList;
    }

    public string GetLevelName()
    {
        return levelName;
    }

}
