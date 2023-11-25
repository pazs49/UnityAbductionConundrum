using UnityEngine;

public class RestartLevel : MonoBehaviour
{
  public void Restart()
  {
    LevelManager.instance.GameOver(true);
  }
}
