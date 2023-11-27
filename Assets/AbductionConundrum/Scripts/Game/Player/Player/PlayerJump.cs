using UnityEngine;

public class PlayerJump : MonoBehaviour
{
  public float jumpForce;
  public bool isGrounded;

  private Rigidbody2D rb;

  public PlayerGroundChecker pGroundChecker;


  private void Start()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  private void FixedUpdate()
  {
    isGrounded = pGroundChecker.isGrounded;
  }



  public void Jump()
  {
    if (isGrounded)
    {
      //Audio plays 2x sometimes on keyboard but that's fine we're on android lol
      AudioManager.instance.PlaySFX("pJump");
      rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

  }

}
