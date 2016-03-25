using UnityEngine;
using System.Collections;

public class ballController : MonoBehaviour
{
    public float ballSpeed = 5f;
    private Rigidbody2D rigidBall;
    private RaycastHit2D rayHit;

    void Start()
    {
        rigidBall = this.GetComponent<Rigidbody2D>();
        rigidBall.velocity = new Vector2(Random.Range(0f, 1f), Random.Range(0f, 1f));
    }


    void FixedUpdate()
    {


        //Speed limit
        if (rigidBall.velocity.magnitude < ballSpeed || rigidBall.velocity.magnitude > ballSpeed)
        {
            rigidBall.velocity = rigidBall.velocity.normalized * ballSpeed;
        }

        UpdateHitMarker();


    }

    void UpdateHitMarker()
    {
      rayHit = Physics2D.Raycast(transform.position,  rigidBall.velocity);
      if (rayHit.collider != null && rayHit.collider.tag != "Ball")
        {

            Debug.DrawLine(transform.position, rayHit.point, Color.blue, 10f);
            Debug.DrawRay(rayHit.point,Vector2.Reflect(rigidBall.velocity, rayHit.normal), Color.green);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //Randomize bump angle
        rigidBall.AddForce(rigidBall.velocity.normalized + new Vector2(Random.Range(0f, 1f), Random.Range(0f, 1f)));
        if (col.gameObject.tag == "Brick")
        {
            Destroy(col.gameObject);
        }

    }




    void OnDrawGizmos()
    {
      Gizmos.color = Color.green;
      Gizmos.DrawWireSphere(rayHit.point, 0.2f);

    }
}
