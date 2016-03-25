using UnityEngine;
using System.Collections;

public class BrickScript : MonoBehaviour 
{
    public enum BrickType{normal,extraBall};
    public BrickType brickType;
    public int ScoreAmount = 1;
    public int BrickHP = 1;
    
    void DestroyBrick()
    {
     
        if(this.brickType == BrickType.normal)
        {
            BrickHP--;
            GameOverlord.playerScore += ScoreAmount;
            Debug.Log("normal kostka");
            if(BrickHP <= 0)
            {
            Destroy(gameObject);
            }
        }
        
        if(this.brickType == BrickType.extraBall)
        {
         // pridat micek
        
           
        }
        
    }
}
