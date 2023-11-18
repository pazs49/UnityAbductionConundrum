using UnityEngine;

public class GameOver : MonoBehaviour
{
  public GameObject gameOverCanvas;

  private void Start()
  {
    Result();

    DisablePlayerColAndTouchControls();
    GetFunctionsForMyButtons();
  }

  void DisablePlayerColAndTouchControls()
  {
    GameObject player = GameObject.Find("Player");
    player.GetComponent<BoxCollider2D>().enabled = false;
    player.GetComponent<Rigidbody2D>().gravityScale = 0;

    if (GameObject.Find("TouchControlCanvas"))
    {
      Canvas touchCanvas = GameObject.Find("TouchControlCanvas").GetComponent<Canvas>();
      touchCanvas.enabled = false;
    }
  }

  void Result()
  {
    LevelManager.instance.Result();
  }

  void DisplayStarRank()
  {
    print("you got " + LevelManager.instance.GetStarRank());
  }

  void GetFunctionsForMyButtons()
  {
    LevelManager.instance.NextLevel();
  }
}
