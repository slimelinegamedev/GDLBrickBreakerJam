using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{
    public float ballSpeed = 5f;
    private Rigidbody2D rigidBall;
    private RaycastHit2D rayHit;
    public AudioClip hitSoundBrick;
    public AudioClip hitSoundWood;

    private AudioSource audiosrc;

    
void Start()
    {
        rigidBall = GetComponent<Rigidbody2D>();
        StopCoroutine("TimerRoutine");
        StartCoroutine("TimerRoutine");
        audiosrc = GetComponent<AudioSource>();
    }
    
    //Temporarily disables collider to avoid collision issues when shooting the ball
IEnumerator TimerRoutine()
    {
    yield return new WaitForSeconds(0.5f);
    this.gameObject.GetComponent<Collider2D>().enabled = true;
    }
    
    
void FixedUpdate()
    {
        if(GameOverlord.numOfBricks > 0)
        {

            //Speed limit
            if (rigidBall.velocity.magnitude < ballSpeed || rigidBall.velocity.magnitude > ballSpeed)
            {
                rigidBall.velocity = rigidBall.velocity.normalized * ballSpeed;
            }

            UpdateHitMarker();
        }else
        {
             rigidBall.velocity = rigidBall.velocity.normalized * 0;
        }

    }
//Sends raycast to determine the next point of bounce
void UpdateHitMarker()
    {
      rayHit = Physics2D.Raycast(transform.position,  rigidBall.velocity);
      if (rayHit.collider != null && rayHit.collider.tag != "Ignore")
        {
            Debug.DrawLine(transform.position, rayHit.point, Color.blue, 10f);
            Debug.DrawRay(rayHit.point,Vector2.Reflect(rigidBall.velocity, rayHit.normal), Color.green);
        }
    }

void OnCollisionEnter2D(Collision2D col)
    {
    if(col.gameObject.tag != "Player")
    {
       if(col.gameObject.tag != "Wall")
       {
        audiosrc.clip = hitSoundBrick;
       }else
       {
        audiosrc.clip = hitSoundWood;
       }
        
        if(!audiosrc.isPlaying)
    {
      audiosrc.pitch = Random.Range(0.95f,1.05f);
      audiosrc.Play();
    }
    
    }
        //Randomize bump angle
        rigidBall.AddForce(rigidBall.velocity.normalized + new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)));
        //Destroys brick on collision
    if (col.gameObject.tag == "Brick")
        {
        
            col.gameObject.SendMessage("DestroyBrick");
            
        }

    }
    
//Destorys ball when entering death zone
void OnTriggerEnter2D(Collider2D col)
    {
         if(col.tag == "Death")
         {

             GameOverlord.numOfBalls--;
             Destroy(gameObject);
         }
    }


//Debug stuff
void OnDrawGizmos()
    {
      Gizmos.color = Color.green;
      Gizmos.DrawWireSphere(rayHit.point, 0.2f);

    }
}
