using UnityEngine;
using System.Collections;

public class BallShooter : MonoBehaviour 
{
    public float turnSpeed = 5f;
    public Rigidbody2D ball;
    public float maxRot = 30f;
    public float minRot = -30f;
    public float rotka = 0;
    private float timr = 1f;
    
	void Start ()
    {
	GameOverlord.gameState = GameOverlord.GameState.shooting;
	}
	

void Update () 
{
    //Checks for a liviung ball
    timr -= Time.deltaTime;
    if(timr <= 0f)
    {

        if(GameObject.Find("ball(Clone)") == null)
             {
             GameOverlord.gameState = GameOverlord.GameState.shooting;
            }
    timr = 1f;
            
    }
    
    
	if(GameOverlord.gameState == GameOverlord.GameState.shooting)
    {
        //Limited rotating
        rotka += Input.GetAxis("Horizontal")*Time.deltaTime*turnSpeed;
        rotka = Mathf.Clamp(rotka, minRot, maxRot);
        transform.localRotation = Quaternion.AngleAxis(rotka, Vector3.forward);
     
        
        
        //Ball shooting
        if(Input.GetButtonDown("Fire1"))
        {
        
           Rigidbody2D clone = Instantiate(ball,transform.position,transform.rotation) as Rigidbody2D;
           clone.AddForce(gameObject.transform.up);
           GameOverlord.gameState = GameOverlord.GameState.bouncing;
        }
        
    }

}
}
