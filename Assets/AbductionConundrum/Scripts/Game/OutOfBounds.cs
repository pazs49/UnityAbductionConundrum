using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
  GameObject player;
  GameObject yLimit;

  //For firing once
  bool isFired;

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
    if (player != null && !isFired)
    {
      if (player.transform.position.y <= yLimit.transform.position.y)
      {
        LevelManager.instance.GameOver(true);

        isFired = true;
      }
    }
  }
}
