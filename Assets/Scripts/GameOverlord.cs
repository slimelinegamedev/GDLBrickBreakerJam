using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverlord : MonoBehaviour 
{
    
    public enum GameState{bouncing,shooting,done};
    public static GameState gameState;
    
    public static int playerScore = 0;
    public int localBalls = 3;
    public static int numOfBalls = 3;
    public static int numOfBricks;
    public Text scoreText;
    public Text ballText;
	private float timr = 1f;
	void Start() 
    {
    numOfBalls = localBalls;
	}
	
	
	void Update() 
    {
    timr -= Time.deltaTime;
    
    if(timr <= 0f)
    {
     if(GameObject.FindGameObjectWithTag("Player"))
     {
            if(UIOverlord.uiState == UIOverlord.UIState.Playing)
            {
                if(gameState != GameState.done)
                {
                //Checks for living balls
                if(GameObject.Find("ball(Clone)") == null)
                     {
                     if(numOfBalls<= 0)
                        {
                            UIOverlord.uiState = UIOverlord.UIState.GameOver;
                            gameState = GameState.done;
                        }
                    }
                    if(numOfBricks <= 0)
                    {
                        UIOverlord.uiState = UIOverlord.UIState.Victory;
                        gameState = GameState.done;
                    }
               }
            }
            //Updates text info
            scoreText.text = "Score: " + playerScore.ToString();
            ballText.text = " " + numOfBalls.ToString();
         }
        timr = 1f;
    
    }
        
    }    
        
        
    
}
