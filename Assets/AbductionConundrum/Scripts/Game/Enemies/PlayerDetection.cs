using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
  //Must have the interface IEnemy
  public GameObject enemy;
  private void OnTriggerEnter2D(Collider2D collision)
  {
    //Detect player
    if (collision.transform.CompareTag("Player"))
    {
      if (enemy.GetComponent<IEnemy>() != null)
        enemy.GetComponent<IEnemy>().IsActive = true;
    }
  }

  private void OnTriggerExit2D(Collider2D collision)
  {
    if (collision.transform.CompareTag("Player"))
    {
      if (enemy.GetComponent<IEnemy>() != null)
        enemy.GetComponent<IEnemy>().IsActive = true;
    }
  }
}
