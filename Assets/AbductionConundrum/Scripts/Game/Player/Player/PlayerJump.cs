using UnityEngine;

public class PlayerJump : MonoBehaviour
{
  public float jumpForce;
  public Transform groundCheck;
  public LayerMask groundLayer;
  public float groundCheckRadius;
  public bool isGrounded;

  private Rigidbody2D rb;


  private void Start()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  private void FixedUpdate()
  {
    isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
  }

  public void Jump()
  {
    if (isGrounded)
      rb.velocity = new Vector2(rb.velocity.x, jumpForce);
  }

}
