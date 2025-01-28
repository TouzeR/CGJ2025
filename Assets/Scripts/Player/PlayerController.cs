using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb; 
    private Vector2 movement; 
    public float jumpingPower;
    private bool shouldJump;

    public LayerMask groundLayer;
    public Transform groundCheck;
    float Horizontal;
    private float horizontalInput;


    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        movement = new Vector2(horizontalInput, 0);
        if (isGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("hasJumped",true);
        shouldJump = true;
    }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2( horizontalInput*speed,rb.linearVelocityY);
        if(shouldJump){
            rb.AddForce(Vector2.up*jumpingPower, ForceMode2D.Impulse);

            animator.SetBool("hasJumped",false);

            shouldJump = false;
        }
    }

    bool isGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1f, .1f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }
}