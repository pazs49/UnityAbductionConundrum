using UnityEngine;

public class RestartLevel : MonoBehaviour
{
  bool isRestartPressed;
  public void Restart()
  {
    if (!isRestartPressed)
    {
      LevelManager.instance.GameOver(true);
      isRestartPressed = true;
    }
  }
}
