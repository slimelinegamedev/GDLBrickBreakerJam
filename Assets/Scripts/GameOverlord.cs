using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverlord : MonoBehaviour 
{
    
    public enum GameState{bouncing,shooting};
    public static GameState gameState;
    
    public static int playerScore = 0;
    public static int numOfBalls = 3;
    public Text scoreText;
    public Text ballText;
	
	void Start () 
    {
	
	}
	
	
	void Update () 
    {
    
        
        
    
	scoreText.text = "Score: " + playerScore.ToString();
    ballText.text = "Shots: " + numOfBalls.ToString();
	}
}
