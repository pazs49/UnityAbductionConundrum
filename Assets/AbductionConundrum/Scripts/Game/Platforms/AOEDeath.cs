using UnityEngine;

public class AOEDeath : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag("Player"))
    {
      if (LevelManager.instance)
        LevelManager.instance.GameOver(true);
    }
  }
}
