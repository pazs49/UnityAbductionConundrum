using UnityEngine;

public class Projectile : MonoBehaviour
{
  public float lifeTime = 2f;

  //Source:
  //player, enemy
  public string source;

  private void Start()
  {
    Destroy(gameObject, lifeTime);
  }
}
