using UnityEngine;

public class Bouncer : MonoBehaviour
{
  public float bounceForceMultiplier;

  [SerializeField]
  bool isBackSide;

  Rigidbody2D projectileRb;

  Rotator rotator;

  private void Awake()
  {
    if (!isBackSide)
      rotator = GetComponent<Rotator>();
  }

  private void Update()
  {
    if (!isBackSide)
      rotator.Rotate();
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    int layer = collision.gameObject.layer;
    string bouncerLayerName = LayerMask.LayerToName(layer);
    print("hit");
    if (bouncerLayerName == "Projectile" && !isBackSide)
    {
      projectileRb = collision.gameObject.GetComponent<Rigidbody2D>();
      Vector2 normal = collision.contacts[0].normal.normalized;
      Vector2 velocity = projectileRb.velocity;
      Vector2 reflection = Vector2.Reflect(velocity, normal);

      projectileRb.velocity = reflection * -1 * bounceForceMultiplier;
    }
    else if (isBackSide)
    {
      projectileRb = collision.gameObject.GetComponent<Rigidbody2D>();
      projectileRb.velocity = Vector2.zero;
    }

  }
}
