using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
  public GameObject gameOverCanvas;

  public GameObject[] stars;

  public Color disabledImageColor;
  public Color disabledTextColor;
  public GameObject NextLevelButton;
  public GameObject SkipButton;

  private void Start()
  {
    Result();

    StartCoroutine(DisplayStars(CurrentPlayerData.instance.levels[GameManager.instance.currentLevelNumber - 1]));
    DisableUnneededButtons();
  }

  IEnumerator DisplayStars(int rank)
  {
    for (int i = 0; i <= rank - 1; i++)
    {
      stars[i].SetActive(true);
      yield return new WaitForSeconds(.3f);
    }
  }

  void DisablePlayerColAndTouchControls()
  {
    GameObject player = GameObject.Find("Player");
    player.GetComponent<BoxCollider2D>().enabled = false;
    player.GetComponent<Rigidbody2D>().gravityScale = 0;
    player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

    //GameManager.instance.isKeyboardEnabled = false;

    if (GameObject.Find("TouchControlCanvas"))
    {
      Canvas touchCanvas = GameObject.Find("TouchControlCanvas").GetComponent<Canvas>();
      touchCanvas.enabled = false;
    }
  }


  public void Retry()
  {
    LevelManager.instance.Retry();
  }

  public void NextLevel()
  {
    LevelManager.instance.NextLevel();
  }

  public void Skip()
  {
    LevelManager.instance.Skip();
  }

  void Result()
  {
    LevelManager.instance.Result();
  }

  public void MainMenu()
  {
    LevelManager.instance.MainMenu();
  }

  public void DisableButton(GameObject button, Color disabledImageColor, Color disabledTextColor)
  {
    button.GetComponent<Image>().color = disabledImageColor;
    button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = disabledTextColor;
    button.GetComponent<Button>().interactable = false;
  }

  void DisableUnneededButtons()
  {
    DisablePlayerColAndTouchControls();

    print(CurrentPlayerData.instance.levels.Count);
    print(GameManager.instance.currentLevelNumber);

    if (LevelManager.instance.isLevelCompleted)
    {
      DisableButton(SkipButton, disabledImageColor, disabledTextColor);

      //For Last Level disable nextbutton
      if ((LevelManager.instance.currentLevel.level) >= GameManager.instance.levels.Count)
      {
        DisableButton(NextLevelButton, disabledImageColor, disabledTextColor);
      }

    }
    else
    {
      //Disable skip when you die but already completed that level
      if (CurrentPlayerData.instance.levels.Count >= GameManager.instance.currentLevelNumber + 1)
      {
        DisableButton(SkipButton, disabledImageColor, disabledTextColor);
      }
      //Disable next when you die but 
      else
      {
        DisableButton(NextLevelButton, disabledImageColor, disabledTextColor);
      }

      if ((LevelManager.instance.currentLevel.level) >= GameManager.instance.levels.Count)
      {
        DisableButton(SkipButton, disabledImageColor, disabledTextColor);
      }
    }
  }
}
