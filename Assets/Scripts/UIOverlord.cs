using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIOverlord : MonoBehaviour 
{

    public static UIOverlord instanceOfUILord;
    public enum UIState{MainMenu,Playing,GameOver,Victory};
    public static UIState uiState;
    public Animator[] animtrons;
    public Scene curScene;
    

    
    void Awake()
    {   
        if(instanceOfUILord == null)
        {
            instanceOfUILord = this;
        }else
        {
            Destroy(gameObject);
        }
        
        hideUI();
        UIOverlord.uiState = UIOverlord.UIState.MainMenu;
        curScene = SceneManager.GetActiveScene();
    }
    
    
    void Update()
    {
         //Shows GameOver screen
        if(uiState == UIState.GameOver)
        {
            hideUI();
            animtrons[0].SetBool("hideScreen", false);

        }
         //Shows Playing screen
        if(uiState == UIState.Playing)
        {
            hideUI();
         animtrons[1].SetBool("hideScreen", false);
        }
        //Shows Victory Screen
        if(uiState == UIState.Victory)
        {
            hideUI();
            animtrons[2].SetBool("hideScreen", false);

        }
        //Shows MainMenu
        if(uiState == UIState.MainMenu)
        {
            hideUI();
            animtrons[3].SetBool("hideScreen", false);

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
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void StartLevel(string levelName)
    {
        StopCoroutine("loadLevelWaiter");    
        StartCoroutine("loadLevelWaiter", levelName);
    }
    
    IEnumerator loadLevelWaiter(string levelName)
    {
        yield return new WaitForSeconds(2f);
        
        Debug.Log("Loading");
        //Zobrazit loading screen
        yield return new WaitForSeconds(2f);
        
        AsyncOperation async = SceneManager.LoadSceneAsync(levelName,LoadSceneMode.Additive);
        
        while (!async.isDone) {
            Debug.Log("Waiting to load");

            yield return null;
        }
        yield return async;
        //Schovat loading Screen
        Debug.Log("Loading Complete");
        
        //Moves menu object to loaded level and unloads previous one.
        SceneManager.MoveGameObjectToScene(this.gameObject, SceneManager.GetSceneByName(levelName));
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(levelName));
        Debug.Log(curScene.name);
        SceneManager.UnloadScene(curScene.name);
        curScene = SceneManager.GetActiveScene();
        Debug.Log(curScene.name);
        
    }
}
