using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
  GameObject player;
  GameObject yLimit;

  private void Start()
  {
    player = GameObject.Find("Player");
    yLimit = gameObject.transform.GetChild(0).gameObject;
  }

  private void Update()
  {
    Check();
  }

  void Check()
  {
    if (player != null)
    {
      if (player.transform.position.y <= yLimit.transform.position.y)
      {
        player.GetComponent<PlayerMovement>().Death();
      }
    }
  }
}
