using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{

    public enum Scene
    {
        MainMenu,
        LoadingScene,
        Level1,    
        Level2,
        Level3,
        Level4,
        TopScores
    }

    private static Scene targetScene;

    public static void loadSceneAsync(Scene scene)
    {
        targetScene = scene;
       SceneManager.LoadSceneAsync(Scene.LoadingScene.ToString());

  
    }

    public static void loadSceneAsync(LevelType level)
    {

        switch (level)
        {
            case LevelType.Level1:
                targetScene = Scene.Level1;
                ClickerGameManager.Instance.ResetLevel();
                Player.Instance.NewGame();
                SceneManager.LoadSceneAsync(Scene.LoadingScene.ToString());          
                break;
            case LevelType.Level2:
                targetScene = Scene.Level2;
                SceneManager.LoadSceneAsync(Scene.LoadingScene.ToString());
                ClickerGameManager.Instance.ResetLevel();
                break;
            case LevelType.Level3:
                targetScene = Scene.Level3;
                SceneManager.LoadSceneAsync(Scene.LoadingScene.ToString());
                ClickerGameManager.Instance.ResetLevel();
                break;
            case LevelType.Level4:
                targetScene = Scene.TopScores;
                ClickerGameManager.Instance.ResetLevel();
                SceneManager.LoadSceneAsync(Scene.LoadingScene.ToString());
        
                break;
            case LevelType.Level5:
                break;
            default:
                break;
        }

 


    }

    public static void LoaderCallback()
    {
        if (targetScene != Scene.LoadingScene)
        {
         SceneManager.LoadScene(targetScene.ToString());
          
        }
    }

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
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
