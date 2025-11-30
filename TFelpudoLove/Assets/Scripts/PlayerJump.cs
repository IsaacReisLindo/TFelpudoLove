using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 7f;
    public Transform groundCheck;
    public float groundDistance = 0.3f;
    public LayerMask groundLayer;
    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator animator;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        // Faz um raio para baixo para checar chão
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, groundDistance, groundLayer);
        isGrounded = hit.collider != null;

        Debug.DrawRay(groundCheck.position, Vector2.down * groundDistance, Color.red);

        if (isGrounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetTrigger("Jump");
        }
    }
}