using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public const string SCORE_KEY = "Score";

    public event EventHandler<OnSelectedPairedClickersEventArgs> OnPairedClickers;
    public class OnSelectedPairedClickersEventArgs : EventArgs
    {
        public ClickerType ClickerType;
    }


    public event EventHandler<OnMoneyChangedEventArgs> OnMoneyChanged;
    public class OnMoneyChangedEventArgs : EventArgs
    {
        public float Money,          
            Multiplier;

    }
    public event EventHandler OnClickCliker;
    public event EventHandler OnEmptyCliker;


    public static Player Instance { get; private set; }


    private Clicker selectedClicker;

    private float money;
    private int continuousMoneyStreakAmount = 0;
    private int multiplier = 0;

    private TopScoresModel topScoresModel = new TopScoresModel();


    private void Awake()
    {       
        
            Instance = this;
        DontDestroyOnLoad(this.gameObject);
        LoadTopScore();
    }

    public void Reset()
    {
      
        continuousMoneyStreakAmount = 0;
        multiplier = 0;
        selectedClicker = null;
     
    }

    public void NewGame()
    {
        money = 0;
        selectedClicker = null;
        PlayerPrefs.SetFloat(SCORE_KEY, money);
        Reset();
    }

    public  TopScoresModel GetTopScoreSaved()
    {
        return topScoresModel;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameInput.Instance.OnLeftClickEvent += Instance_OnLeftClickEvent;

        if (PlayerPrefs.HasKey(SCORE_KEY))
        {
            money = PlayerPrefs.GetFloat(SCORE_KEY);
            OnMoneyChanged?.Invoke(this, new OnMoneyChangedEventArgs { Money = money, Multiplier = multiplier });
        }
      

    }

    private void Instance_OnPauseAction(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void Instance_OnLeftClickEvent(object sender, EventArgs e)
    {
        if (ClickerGameManager.Instance.IsGamePaused())
        {
            return;
        }


        var mousePosition = GameInput.Instance.inputSystem.UI.Point.ReadValue<Vector2>();

        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        //se colpisco qualcosa
        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.collider.gameObject;
            Clicker clicker = hitObject.GetComponent<Clicker>();

            //se ho cliccato su un clicker
            if (clicker != null)
            {
                clicker.Clicked();
                OnClickCliker?.Invoke(this, EventArgs.Empty);

                if (selectedClicker == null)
                {
                    selectedClicker = clicker;
                }
                else
                {
                    //verifico se i due clicker hanno lo stesso tipo
                    if (selectedClicker.GetClickerSO().ClickerType == clicker.GetClickerSO().ClickerType && clicker.GetInstanceID() != selectedClicker.GetInstanceID())
                    {
                       //se clicco un clicker uguale
                            money += selectedClicker.GetClickerSO().Value;
                            continuousMoneyStreakAmount += selectedClicker.GetClickerSO().Value;
                            multiplier++;
                            OnMoneyChanged?.Invoke(this, new OnMoneyChangedEventArgs { Money = money, Multiplier = multiplier });
                            OnPairedClickers?.Invoke(this, new OnSelectedPairedClickersEventArgs { ClickerType = selectedClicker.GetClickerSO().ClickerType });


                            //se sono uguali li distruggo
                            selectedClicker.Deselected();
                              clicker.Deselected();
                            Destroy(selectedClicker.gameObject);
                            Destroy(clicker.gameObject);
                            Debug.Log(money.ToString());
                        
                    } else
                    {

                       
                     
                        if(money < 0)
                        {
                            money = 0;
                        }
                        ResetMultiplier();
                        OnMoneyChanged?.Invoke(this, new OnMoneyChangedEventArgs { Money = money, Multiplier = multiplier });

                        //se sono diversi li deseleziono
                        selectedClicker.Deselected();
                        clicker.Deselected();
                        selectedClicker = null;
                    
                    
                        Debug.Log(money.ToString());

                    }
                }

            }
            else
            {
                ResetMultiplier();
                OnEmptyCliker.Invoke(this, EventArgs.Empty);
            }

        }
        else
        {
            OnEmptyCliker.Invoke(this, EventArgs.Empty);
            ResetMultiplier();

        }
    }


    public void ResetMultiplier()
    {


        if (continuousMoneyStreakAmount == 0 )
        {
            continuousMoneyStreakAmount = 1;
        }
        if (multiplier == 0)
        {
            multiplier = 1;
        }
        if (continuousMoneyStreakAmount != 1 && multiplier != 1)
        {
            money += continuousMoneyStreakAmount * multiplier;
        }
    
        multiplier = 0;
        continuousMoneyStreakAmount = 0;
        OnMoneyChanged?.Invoke(this, new OnMoneyChangedEventArgs { Money = money, Multiplier = multiplier });
    }


    public void CheckFinalScore()
    {
        ResetMultiplier();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetScore()
    {
        return money;

    }


    public void LoadTopScore()
    {
        topScoresModel.Initialize(resetScore:false);

    }
}

