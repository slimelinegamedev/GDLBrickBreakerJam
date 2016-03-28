using UnityEngine;
using System.Collections;

public class BatController : MonoBehaviour
{
    public float batSpeed = 5f;
    private Rigidbody2D rigio;
    private Animator anim;
    public AudioClip hitSound;
    private AudioSource audiosrc;
    public GameObject superObject;
  void Start()
  {
    rigio = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
    audiosrc = GetComponent<AudioSource>();
      if(GameObject.Find("!SuperObject")==null)
         {
             Instantiate(superObject,new Vector3(0,0,0),transform.rotation);
         }
  }


  void FixedUpdate()
   {
  //Bat movement
  if(GameOverlord.gameState == GameOverlord.GameState.bouncing)
  {
    rigio.velocity = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"))*batSpeed;
  }else
  {
   rigio.velocity = Vector2.zero;   
  }
      if(anim.GetCurrentAnimatorStateInfo(0).IsName("batHit")){
          anim.SetBool("hit",false);
                 }
  }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        //Destroys brick on collision
    if (col.gameObject.tag == "Ball")
        {   
            if(!audiosrc.isPlaying)
                {
                  audiosrc.pitch = Random.Range(0.95f,1.05f);
                  audiosrc.clip = hitSound;
                  audiosrc.Play();
                }
                anim.SetBool("hit",true);
            
        }

    }


}
