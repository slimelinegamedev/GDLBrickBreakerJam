using UnityEngine;
using System.Collections;

public class BrickScript : MonoBehaviour 
{
    public enum BrickType{normal,extraBall};
    public BrickType brickType;
    public int ScoreAmount = 1;
    public int BrickHP = 1;
    public Rigidbody2D ball;
    void Awake()
    {
        //On start incerease total number of bricks
       GameOverlord.numOfBricks++;
    }
    
    
    void DestroyBrick()
    {
     
        if(this.brickType == BrickType.normal)
        {
            BrickHP--;
            GameOverlord.playerScore += ScoreAmount;

        }
        //Spawns extra ball and adds total number of balls
        if(this.brickType == BrickType.extraBall)
        {
        BrickHP--;
        GameOverlord.numOfBalls++;
        GameOverlord.playerScore += ScoreAmount;
        gameObject.GetComponent<Collider2D>().enabled = false;
        Rigidbody2D clone = Instantiate(ball,transform.position,transform.rotation) as Rigidbody2D;
        clone.AddForce(Vector2.left);


        }
        
        //Destoys brick
        if(BrickHP <= 0)
        {
        GameOverlord.numOfBricks--;
        Destroy(gameObject);
        } 
    }
}
