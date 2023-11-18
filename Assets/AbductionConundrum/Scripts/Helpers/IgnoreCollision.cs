using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
  [Header("Only tags, not by name")]
  public string[] tags;

  Transform[] gosToIgnore;

  private void OnCollisionEnter2D(Collision2D collision)
  {
    print(collision.gameObject.tag);
    foreach (string str in tags)
    {
      if (collision.gameObject.tag == str)
      {
        print(str + " is now ignored!");
        Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
      }
    }

  }
}
