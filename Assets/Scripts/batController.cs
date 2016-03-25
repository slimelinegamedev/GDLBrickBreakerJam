using UnityEngine;
using System.Collections;

public class BatController : MonoBehaviour
{
    public float batSpeed = 5f;
    private Rigidbody2D rigio;

  void Start()
  {
    rigio = GetComponent<Rigidbody2D>();
  }


  void FixedUpdate()
   {
  if(GameOverlord.gameState == GameOverlord.GameState.bouncing)
  {
    rigio.velocity = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"))*batSpeed;
  }else
  {
   rigio.velocity = Vector2.zero;   
  }
      
  }
}
