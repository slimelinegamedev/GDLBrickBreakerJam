using UnityEngine;
using System.Collections;

public class BallShooter : MonoBehaviour 
{
    public float turnSpeed = 5f;
    public Rigidbody2D ball;
    
	void Start ()
    {
	GameOverlord.gameState = GameOverlord.GameState.shooting;
	}
	

void Update () 
{
	if(GameOverlord.gameState == GameOverlord.GameState.shooting)
    {
	 transform.Rotate(Vector3.back*Input.GetAxis("Horizontal")*Time.deltaTime*turnSpeed);
     if(Input.GetButtonDown("Fire1"))
        {
        
           Rigidbody2D clone = Instantiate(ball,transform.position,transform.rotation) as Rigidbody2D;
           clone.AddForce(gameObject.transform.up);
           GameOverlord.gameState = GameOverlord.GameState.bouncing;
        }
        
    }

}
}
