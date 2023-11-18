using UnityEngine;

public class StarCollectible : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag("Player") || collision.CompareTag("Projectile"))
    {
      LevelManager.instance.starsCollected += 1;

      Destroy(gameObject);
    }
  }
}
