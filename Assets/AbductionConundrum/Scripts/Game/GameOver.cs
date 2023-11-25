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

    //Level not complete
    //For non-latest level
    if (
      //Check for null
      CurrentPlayerData.instance.levels.Count >= GameManager.instance.currentLevelNumber + 1
      && !LevelManager.instance.isLevelCompleted
      //Check for current level
      && CurrentPlayerData.instance.levels[GameManager.instance.currentLevelNumber - 1] >= 1
      //Check for next level
      && CurrentPlayerData.instance.levels[GameManager.instance.currentLevelNumber] >= 1
      )
    {
      print("Level not complete but can move to the next level because current and next level is unlocked");
      DisableButton(SkipButton, disabledImageColor, disabledTextColor);

      if ((CurrentPlayerData.instance.levels.Count - GameManager.instance.currentLevelNumber) == 1
        && (GameManager.instance.currentLevelNumber - GameManager.instance.levels.Count) == 0)
      {
        DisableButton(NextLevelButton, disabledImageColor, disabledTextColor);
      }
    }
    //Level Complete
    //Last level therefore no next level
    else
    {
      DisableButton(SkipButton, disabledImageColor, disabledTextColor);
      if ((CurrentPlayerData.instance.levels.Count - GameManager.instance.currentLevelNumber) == 1
        && (GameManager.instance.currentLevelNumber - GameManager.instance.levels.Count) == 0)
      {
        DisableButton(NextLevelButton, disabledImageColor, disabledTextColor);
      }
      else
      {

      }
    }

    //Also not level complete. Disable next level button because next level not unlocked
    if (CurrentPlayerData.instance.levels.Count == GameManager.instance.currentLevelNumber
      && !LevelManager.instance.isLevelCompleted)
    {
      DisableButton(NextLevelButton, disabledImageColor, disabledTextColor);
    }
  }
}
