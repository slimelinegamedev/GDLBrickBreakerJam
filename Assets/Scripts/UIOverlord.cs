using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIOverlord : MonoBehaviour 
{

    public static UIOverlord instanceOfUILord;
    public enum UIState{MainMenu,Playing,GameOver,Victory,Loading,LevelSelect};
    public static UIState uiState;
    public Animator[] animtrons;
    public Scene curScene;
    public float Timer=1f;
    private string origSceneName;

    
    void Awake()
    {
        
        if(instanceOfUILord == null)
        {
            instanceOfUILord = this;
        }else
        {
            Destroy(gameObject);
        }
        
        UIOverlord.uiState = UIOverlord.UIState.MainMenu;
        curScene = SceneManager.GetActiveScene();
    }
    
    
    void Update()
    {
        Timer -= Time.deltaTime;
    if(Timer <= 0f)
    {
    if(uiState == UIState.GameOver)
        {
        hideUI();
        animtrons[0].SetBool("hideScreen", false);
        }
        if(uiState == UIState.Playing)
        {
        hideUI();
        animtrons[1].SetBool("hideScreen", false);
        }
        if(uiState == UIState.Victory)
        {
        hideUI();
        animtrons[2].SetBool("hideScreen", false);
        }
        if(uiState == UIState.MainMenu)
        {
        hideUI();
        animtrons[3].SetBool("hideScreen", false);
        }
        if(uiState == UIState.Loading)
        {
        hideUI();
        animtrons[4].SetBool("hideScreen", false);
        }
        if(uiState == UIState.LevelSelect)
        {
        hideUI();
        animtrons[5].SetBool("hideScreen", false);
        }else
    {
        Timer = 1f;
    }
    }
        
        
    }
    
    public void switchScreen(int i)
    {
        if(i == 0)
        {
        uiState = UIState.GameOver;
        }else if(i == 1)
        {
        uiState = UIState.Playing;
        }else if(i == 2)
        {
        uiState = UIState.Victory;
        }else if(i == 3)
        {
        uiState = UIState.MainMenu;
        }else if(i == 4)
        {
        uiState = UIState.Loading;
        }
        else if(i == 5)
        {
        uiState = UIState.LevelSelect;
        }
    }
    
    //Fires hide animation on all UI panels
    void hideUI()
    {
        for(int i = 0; i< animtrons.Length; i++)
        {
            animtrons[i].SetBool("hideScreen", true);
        }
    }
    
    //Restart button
    public void RestartGame()
    {
        GameOverlord.gameState = GameOverlord.GameState.shooting;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        StartLevel(SceneManager.GetActiveScene().name);
        

    }

    public void StartLevel(string levelName)
    {
        StopCoroutine("loadLevelWaiter");    
        StartCoroutine("loadLevelWaiter", levelName);
    }
    
    
    //Load level with loading screen
    IEnumerator loadLevelWaiter(string levelName)
    {
        GameOverlord.gameState = GameOverlord.GameState.shooting;
        Debug.Log("Start Loading");
        //Show loading screen
        switchScreen(4);
        yield return new WaitForSeconds(5f);
        
        AsyncOperation async = SceneManager.LoadSceneAsync(levelName,LoadSceneMode.Additive);
        
        
        
        yield return async;
        //Moves menu object to loaded level and unloads previous one.
        SceneManager.MoveGameObjectToScene(this.gameObject, SceneManager.GetSceneByName(levelName));
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(levelName));


        SceneManager.UnloadScene(curScene.name);
        curScene = SceneManager.GetActiveScene();

        yield return new WaitForSeconds(5f);
        
        //Hide loading Screen
        if(!animtrons[4].GetBool(("hideScreen")))
        {
        animtrons[4].SetBool("hideScreen", false);
        }
        
        
        Debug.Log("Loading Done");
        
    }
}
