using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


/// <summary>
/// Sono presenti 4 clicker diversi
/// i clicker sono messi a rettangolo standard ma su un quarto alla volta si sposta un blocco visivo che impedisce di vedere e cliccare i clicker sottostanti.
/// il blocco rimane fermo per 2 secondi e poi si sposta su un altro quarto e continua per tutta la partita
/// </summary>
public class Level3 : ILevel
{
    public List<ClickerSO> CreateClickerList(List<ClickerSO> AllowedSceneClickersList, int totalPositions)
    {
        var mySceneClickerList = new List<ClickerSO>();

        //verifica che le totalPositions sia un multiplo di 4
        if (totalPositions % 4 != 0)
        {
            Debug.LogError("totalPositions non è un multiplo di 4");
            return null;
        }


        for (int i = 0; i < totalPositions / 4; i++)
        {
            //seleziono il clickerSO verde
            var clickerSO = AllowedSceneClickersList.FirstOrDefault(x => x.ClickerType == ClickerType.Green);
            mySceneClickerList.Add(clickerSO);
        }

        for (int i = 0; i < totalPositions / 4; i++)
        {
            //seleziono il clickerSO verde
            var clickerSO = AllowedSceneClickersList.FirstOrDefault(x => x.ClickerType == ClickerType.Red);
            mySceneClickerList.Add(clickerSO);
        }

        for (int i = 0; i < totalPositions / 4; i++)
        {
            //seleziono il clickerSO verde
            var clickerSO = AllowedSceneClickersList.FirstOrDefault(x => x.ClickerType == ClickerType.Purple);



            mySceneClickerList.Add(clickerSO);

        }
        for (int i = 0; i < totalPositions / 4; i++)
        {
            //seleziono il clickerSO verde
            var clickerSO = AllowedSceneClickersList.FirstOrDefault(x => x.ClickerType == ClickerType.Blue);



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

    private string levelName = "Level3!";
}
