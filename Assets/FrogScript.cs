using UnityEngine;

public class FrogScript : MonoBehaviour
{
    public Rigidbody2D body;
    public Animator animator;
    public float speed = 2f;
    public float jumpSpeed = 4f;
    private bool grounded = true;
    
    void Update()
    {
        // movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = body.velocity.y;
        if (Input.GetKeyDown(KeyCode.Space) && grounded) 
        {
            vertical = jumpSpeed;
            grounded = false;
        }
        body.velocity = new Vector2(horizontal * speed, vertical);
        
        // transforms
        if (horizontal > 0.01f)
        {
            transform.localScale = new Vector2(1, 1);
        }
        if (horizontal < -0.01f)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        
        // animations
        animator.SetBool("running", horizontal != 0f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
}
