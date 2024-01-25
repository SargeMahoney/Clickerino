using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.CullingGroup;

public class ClickerGameManager : MonoBehaviour
{



    private enum State
    {
        WaitingToStart,
        CountdownToStart,
        GamePlaying,
        GameOver
    }

    public event EventHandler OnStateChanged;
    public event EventHandler OnGamePaused;
    public event EventHandler OnGameUnpaused;
    public event EventHandler OnGameFinished;
    public event EventHandler OnGameOver;

    [SerializeField]
    private LevelType currentLevelType;


    private ILevel currentLevel;

    private State state;
    private float waitingToStartTimer = 0.2f;
    private float countDownToStartTimer = 3f;
    private float gamePlayingTimer;

    private bool isGamePaused = false;
    private bool isSceneCompleted = false;

    public static ClickerGameManager Instance;

    [SerializeField] Clicker clicker;


    [SerializeField]
    private List<ClickerSO> sceneClickersListSO;



    private List<ClickerSO> SceneClickersList { get; set; } = new List<ClickerSO>();
    
    void Awake()
    {
         Instance = this;
        
      
        state = State.WaitingToStart;
        DontDestroyOnLoad(gameObject);
      
    }

    // Start is called before the first frame update
    void Start()
    {
        
        Player.Instance.OnPairedClickers += Instance_OnPairedClickers;
        GameInput.Instance.OnPauseAction += Instance_OnPauseAction;
        CreateRandomClickerList();
    }
    private void Instance_OnPauseAction(object sender, EventArgs e)
    {
        TogglePauseGame();
    }

    public void TogglePauseGame()
    {
        isGamePaused = !isGamePaused;
        if (isGamePaused)
        {
            Time.timeScale = 0f;
            OnGamePaused?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            OnGameUnpaused?.Invoke(this, EventArgs.Empty);
            Time.timeScale = 1f;
        }

    }

    private void Instance_OnPairedClickers(object sender, Player.OnSelectedPairedClickersEventArgs e)
    {
       //rimuovo dalla lista 2 clicker dello stesso tipo
       var clickersToRemove = SceneClickersList.Where(x => x.ClickerType == e.ClickerType).Take(2).ToList();
    
          foreach (var clicker in clickersToRemove)
        {
                SceneClickersList.Remove(clicker);
          }
    
          //se la lista è vuota, HO VINTO 
          if (SceneClickersList.Count == 0)
          {
              
            isSceneCompleted = true;
            Time.timeScale = 0f;
            Player.Instance.ResetMultiplier();
            PlayerPrefs.SetFloat(Player.SCORE_KEY, Player.Instance.GetScore());
       
            OnGameFinished?.Invoke(this, EventArgs.Empty);
          }
         
    }

    public ILevel GetCurrentLevel()
    {
        return currentLevel;
    }
    public bool IsGamePlaying()
    {
        return state == State.GamePlaying;
    }

    public void ResetLevel()
    {
        state = State.WaitingToStart;
        waitingToStartTimer = 0.2f;
        isSceneCompleted = false;
        Time.timeScale = 1;
    }
    public bool IsGamePaused()
    {
        return isGamePaused;
    }

    public bool IsCountdownToStartActive()
    {
        return state == State.CountdownToStart;
    }
    public bool IsGameOver()
    {
        return state == State.GameOver;
    }

    public float GetCountdownToStartTimer()
    {
        return countDownToStartTimer;
    }

    public float GetPlayingTimer()
    {
        return  gamePlayingTimer;
    }

    public float GetPlayingTimerNormalized()
    {
        return 1 - gamePlayingTimer / MainArea.Instance.GetMaxPlayableTime();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.WaitingToStart:
                waitingToStartTimer -= Time.deltaTime;
                if (waitingToStartTimer < 0)
                {
                    state = State.CountdownToStart;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.CountdownToStart:
                countDownToStartTimer -= Time.deltaTime;
                if (countDownToStartTimer < 0)
                {
                    state = State.GamePlaying;
                    gamePlayingTimer = MainArea.Instance.GetMaxPlayableTime();
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GamePlaying:
                gamePlayingTimer -= Time.deltaTime;
                if (gamePlayingTimer < 0)
                {
                    state = State.GameOver;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GameOver:
                //tempi finito!
                if (!isSceneCompleted)
                {
                    //mostra il game over
                   OnGameOver?.Invoke(this, EventArgs.Empty);
                }
               
                break;
            default:
                break;
        }
    }

    public void CreateRandomClickerList()
    {

        switch (currentLevelType)
        {
            case LevelType.Level1:
                currentLevel = new Level1();
                Player.Instance.NewGame();
                break;
            case LevelType.Level2:
                currentLevel = new Level2();
                break;
         
            case LevelType.Level3:
                currentLevel = new Level3();
                break;
            default:
                currentLevel = new Level1();
                break;
        }

        SceneClickersList = currentLevel.CreateClickerList(sceneClickersListSO, MainArea.Instance.GetTotalPositions());       

        MainArea.Instance.InitializeClickers(SceneClickersList);
    }  
}




