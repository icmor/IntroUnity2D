using UnityEngine;

public class FrogScript : MonoBehaviour
{
    public Rigidbody2D body;
    public float speed = 2f;
    public float jumpSpeed = 4f;
    private bool grounded = true;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded) 
        {
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, jumpSpeed);
            grounded = false;
        }
        else
        {
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

//    void OnCollisionExit2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Ground"))
//        {
//            grounded = false;
//        }
//    }
}
