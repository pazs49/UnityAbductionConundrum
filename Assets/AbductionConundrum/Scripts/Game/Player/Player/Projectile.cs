using UnityEngine;

public class Projectile : MonoBehaviour
{
  public float lifeTime = 2f;

  private void Start()
  {
    Destroy(gameObject, lifeTime);
  }
}
