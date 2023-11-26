using UnityEngine;

public class Spike : MonoBehaviour
{
  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("Player"))
    {
      if (LevelManager.instance != null)
        LevelManager.instance.GameOver(true);
    }
  }
}
