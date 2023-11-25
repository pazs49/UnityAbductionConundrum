using UnityEngine;

public class Bouncer : MonoBehaviour
{
  public float forceAmount;

  Rotator rotator;

  private void Awake()
  {
    rotator = GetComponent<Rotator>();
  }

  private void Update()
  {
    rotator.Rotate();
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.tag == "Projectile")
    {
      Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
      rb.AddForce(rb.velocity * forceAmount, ForceMode2D.Force);
    }
  }
}
