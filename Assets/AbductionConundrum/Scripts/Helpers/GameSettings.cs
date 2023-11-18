using UnityEngine;

public class GameSettings : MonoBehaviour
{
  private void Start()
  {
    Application.targetFrameRate = 60;
    if (Application.platform == RuntimePlatform.Android)
    {
      GameManager.instance.isKeyboardEnabled = false;
    }
  }
}
