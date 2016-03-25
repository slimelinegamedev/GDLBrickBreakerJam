using UnityEngine;
using System.Collections;

public class batController : MonoBehaviour
{
    public float batSpeed = 5f;
    private Rigidbody2D rigio;

  void Start()
  {
    rigio = this.GetComponent<Rigidbody2D>();
  }


  void FixedUpdate()
   {
    rigio.velocity = Vector2.up*Input.GetAxis("Vertical")*batSpeed;

  }
}
