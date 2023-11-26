using UnityEngine;

public class StarCollectible : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collision)
  {
    //I added check for levelmanager so I can able to debug the game without going to mainmenu
    if (LevelManager.instance != null && (collision.gameObject.CompareTag("Player") || ((collision.CompareTag("Projectile")
      && collision.GetComponent<Projectile>().source == "player"))))
    {
      AudioManager.instance.PlaySFX("starCollected");

      LevelManager.instance.starsCollected += 1;

      Destroy(gameObject);
    }
  }
}
