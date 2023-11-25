using UnityEngine;

public class StarCollectible : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.CompareTag("Player") || (collision.CompareTag("Projectile")
      && collision.GetComponent<Projectile>().source == "player"))
    {
      LevelManager.instance.starsCollected += 1;

      Destroy(gameObject);
    }
  }
}
