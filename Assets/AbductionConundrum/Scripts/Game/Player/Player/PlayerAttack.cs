using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
  public GameObject bullet;
  public int bulletCount;
  public float shootForce;

  private PlayerAnimation anim;

  private void Awake()
  {
    anim = GetComponent<PlayerAnimation>();
  }

  public void Shoot1()
  {
    if (bullet != null)
    {
      anim.ShootAnim();
      Vector3 position = transform.position + (transform.localScale.x == -1 ? new Vector3(0f, 0.4f, 0) : new Vector3(0f, 0.4f, 0));
      GameObject mBullet = Instantiate(bullet, position, Quaternion.identity);
      Rigidbody2D rb = mBullet.GetComponent<Rigidbody2D>();
      rb.AddForce((transform.localScale.x == -1 ? Vector2.left + Vector2.up : Vector2.right + Vector2.up) * shootForce, ForceMode2D.Impulse);
    }

  }
}
