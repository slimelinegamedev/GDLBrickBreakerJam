using UnityEngine;
using System.Collections;

public class BatController : MonoBehaviour
{
    public float batSpeed = 5f;
    private Rigidbody2D rigio;
    private Animator anim;

  void Start()
  {
    rigio = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
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
      
  }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        //Destroys brick on collision
    if (col.gameObject.tag == "Ball")
        {
             if(!anim.GetCurrentAnimatorStateInfo(0).IsName("batHit")){
                anim.SetTrigger("hit");
                 }
            
        }

    }
}
