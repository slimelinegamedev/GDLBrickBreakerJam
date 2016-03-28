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
    public Animator anim;
    public AudioClip catapult;
    public AudioSource audiosrc;
    
	void Start ()
    {
    UIOverlord.uiState = UIOverlord.UIState.Playing;
	GameOverlord.gameState = GameOverlord.GameState.shooting;
    GameOverlord.numOfBalls = 3;
    GameOverlord.playerScore = 0;
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
        if(GameOverlord.numOfBalls > 0)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                audiosrc.clip = catapult;
                audiosrc.Play();
                anim.SetTrigger("fire");
               Rigidbody2D clone = Instantiate(ball,transform.position,transform.rotation) as Rigidbody2D;
               clone.AddForce(gameObject.transform.up);
               GameOverlord.gameState = GameOverlord.GameState.bouncing;
            }
        }
    }

}
}
