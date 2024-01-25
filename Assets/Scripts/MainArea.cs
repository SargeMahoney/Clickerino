using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MainArea : MonoBehaviour
{

    public static MainArea Instance;

    [SerializeField] List<PositionBase> Positions;
    [SerializeField] float maxPlayableTime = 20f;

    private void Awake()
    {
        Instance = this;
    }

    public float GetMaxPlayableTime()
    {
        return maxPlayableTime;
    }

    public int GetTotalPositions()
    {
        return Positions.Count;
    }
    public void InitializeClickers(List<ClickerSO> clickers)
    {


        foreach (var clicker in clickers)
        {
            var emptyPositions = Positions.Where(x => !x.HaveClicker()).ToList();
          

            //prendi una posizione a caso
            int randomIndex = UnityEngine.Random.Range(0, emptyPositions.Count);
            var position = emptyPositions[randomIndex];



            var myClicker = Instantiate(clicker.prefab, position.transform.position, Quaternion.identity);
           var clickerScript = myClicker.GetComponent<Clicker>();
            clickerScript.SetClickerSO(clicker);
          
            position.SetClicker(clicker);
            myClicker.SetParent(position.transform.parent);
            myClicker.gameObject.SetActive(true);
        }


        
    
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
