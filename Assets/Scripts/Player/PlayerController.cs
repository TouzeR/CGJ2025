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

    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
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
        rb.linearVelocity = movement * speed;
        if(shouldJump){
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
            animator.SetBool("hasJumped",false);

            shouldJump = false;
        }
    }

    bool isGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1f, .1f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }
}