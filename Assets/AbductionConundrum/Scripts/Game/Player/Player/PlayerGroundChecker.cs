using UnityEngine;

public class PlayerGroundChecker : MonoBehaviour
{
  public bool isGrounded;

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (LayerMask.LayerToName(collision.gameObject.layer) == "Ground")
      isGrounded = true;
  }

  private void OnTriggerStay2D(Collider2D collision)
  {
    if (LayerMask.LayerToName(collision.gameObject.layer) == "Ground")
      isGrounded = true;
  }

  private void OnTriggerExit2D(Collider2D collision)
  {
    if (LayerMask.LayerToName(collision.gameObject.layer) == "Ground")
      isGrounded = false;
  }
}
