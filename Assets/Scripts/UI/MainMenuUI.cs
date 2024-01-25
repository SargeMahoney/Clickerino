using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{

    [SerializeField] Button startButton;
    [SerializeField] Button topScoresButton;
    [SerializeField] Button exitButton;
    [SerializeField] Transform greenContainer;
    [SerializeField] Transform blueContainer;
    [SerializeField] Loader.Scene FirstLevel;

    private float movingRightMax = 4f;
    private float movingGreen = 0f;
    private float movingBlue = 0f;



    private bool isGreenMovingRight = true;
    private bool isBlueMovingRight = true;

    public event EventHandler OnBounce;




    // Start is called before the first frame update
    void Start()
    {

        startButton.onClick.AddListener(() =>
        {

            Loader.loadSceneAsync(Loader.Scene.Level1);

        });
        topScoresButton.onClick.AddListener(() =>
        {
            Loader.loadSceneAsync(Loader.Scene.TopScores);
        });
        exitButton.onClick.AddListener(() =>
        {
          //exit the application
          Application.Quit();

        });


    
    }

    private void Awake()
    {

  
        
    }
    // Update is called once per frame
    void Update()
    {
        GreenContainerMoving();
        BlueContainerMoving();
    }


    public void GreenContainerMoving()
    {
        if (movingGreen <= movingRightMax && isGreenMovingRight)
        {
           
             greenContainer.Translate(Vector3.right * Time.deltaTime * 15f);
            movingGreen = movingGreen + Time.deltaTime;

        }
        else
        {
         
            //sposta indietro il greencontainer sull'asse delle x
            isGreenMovingRight = false;
         
            greenContainer.Translate(Vector3.left * Time.deltaTime * 15f);
    
            movingGreen = movingGreen - Time.deltaTime;
        }



        if (!isGreenMovingRight && movingGreen <= 0)
        {
            isGreenMovingRight = true;
   
        }


    }

    private IEnumerator DelayedMovementBlue()
    {
        yield return new WaitForSeconds(1f); // Ritardo di un secondo
    
    }

   private bool IsBounce = false;
    public void BlueContainerMoving()
    {
  

        if (movingBlue <= (movingRightMax+1f) && isBlueMovingRight)
        {
           
            //sposta avanti il greencontainer sull'asse delle x
            blueContainer.Translate(Vector3.right * Time.deltaTime * 12f);
            movingBlue = movingBlue + Time.deltaTime;

        }
        else
        {
         
        
            //sposta indietro il greencontainer sull'asse delle x
            isBlueMovingRight = false;
            blueContainer.Translate(Vector3.left * Time.deltaTime * 12f);
            movingBlue = movingBlue - Time.deltaTime;
        }

        if (!isBlueMovingRight && movingBlue <= 0)
        {
            isBlueMovingRight = true;
   
        }

    }
}
