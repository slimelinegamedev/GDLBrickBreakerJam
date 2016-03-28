using UnityEngine;
using System.Collections;

public class BrickScript : MonoBehaviour 
{
    public enum BrickType{normal,extraBall};
    public BrickType brickType;
    public int ScoreAmount = 1;
    public int BrickHP = 1;
    public Rigidbody2D ball;
    public Sprite dmgSprite;
    private Animator anim;
    
    void Awake()
    {
        //On start incerease total number of bricks
       GameOverlord.numOfBricks++;
        anim = gameObject.GetComponent<Animator>();
    }
    
    void OnCollisionEnter2D()
    {
    }
    void DestroyBrick()
    {
        anim.SetTrigger("hit");

        BrickHP--;
        gameObject.GetComponent<SpriteRenderer>().sprite = dmgSprite;
        if(this.brickType == BrickType.normal)
        {
            
            gameObject.GetComponent<SpriteRenderer>().sprite = dmgSprite;
            GameOverlord.playerScore += ScoreAmount;

        }
        //Spawns extra ball and adds total number of balls
        if(this.brickType == BrickType.extraBall)
        {
        GameOverlord.numOfBalls++;
        GameOverlord.playerScore += ScoreAmount;
        gameObject.GetComponent<Collider2D>().enabled = false;
        Rigidbody2D clone = Instantiate(ball,transform.position,transform.rotation) as Rigidbody2D;
        clone.AddForce(Vector2.left);


        }
        
        //Destoys brick
        if(BrickHP <= 0)
        {
        StartCoroutine("DestroyLater");
        } 
    }
    
    IEnumerator DestroyLater()
    {
    
    yield return new WaitForSeconds(0.25f);
    GameOverlord.numOfBricks--;
    Destroy(gameObject);
    
    }
}
