using UnityEngine;
using UnityEngine.Tilemaps;

public class Projectile : MonoBehaviour
{
  public float lifeTime = 2f;

  //Source:
  //player, enemy
  public string source;

  float timer = 0;
  private void Start()
  {

  }
  private void Update()
  {
    if (timer >= lifeTime)
    {
      Destroy(gameObject);
    }
    timer += Time.deltaTime;
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.tag == "Bouncer")
    {
      timer = 0;
    }

    if (collision.gameObject.tag == "Breakables")
    {
      BreakTile(collision.gameObject.GetComponent<Tilemap>(), collision);

    }
  }

  void BreakTile(Tilemap tilemap, Collision2D collision)
  {
    Vector3 hitPosition = Vector3.zero;
    foreach (ContactPoint2D hit in collision.contacts)
    {
      hitPosition.x = hit.point.x - 0.15f * hit.normal.x;
      hitPosition.y = hit.point.y - 0.15f * hit.normal.y;
      tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);
    }
  }
}
