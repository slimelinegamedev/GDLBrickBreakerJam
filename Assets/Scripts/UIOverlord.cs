using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIOverlord : MonoBehaviour 
{

    
    public enum UIState{Playing,GameOver,Victory};
    public static UIState uiState;
    public static int UIAnimationState = 0;
    public Animator[] animtrons;
    
    

    
    void Start()
    {
        UIOverlord.uiState = UIOverlord.UIState.Playing;
        hideUI();
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
}
