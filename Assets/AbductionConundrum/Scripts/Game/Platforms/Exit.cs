using UnityEngine;

public class Exit : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag("Player"))
    {
      LevelManager.instance.GameOver(false);
    }
  }
}
