using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
  public static LevelManager instance;

  public Level currentLevel;

  public bool isLevelCompleted;

  public int stars;
  public int starsCollected;

  public GameObject gameOverCanvas;

  private void Awake()
  {
    instance = this;
  }

  private void Start()
  {
    LoadLevelData();
    print(stars + " are needed for 3 star completion!");
  }

  public void LoadLevelData()
  {
    currentLevel = GameManager.instance.GetCurrentLevelData();
    stars = currentLevel.stars;
  }

  public int GetStarRank()
  {
    if (stars != 0)
    {

      if (starsCollected / stars >= 1)
      {
        return 3;
      }

      else if (starsCollected / stars >= .66f)
      {
        return 2;
      }

      else if (starsCollected / stars >= .33f)
      {
        return 1;
      }
    }

    return 1;
  }

  public void Retry()
  {
    string currentSceneName = SceneManager.GetActiveScene().name;
    GameManager.instance.ChangeScene(currentSceneName);
  }

  //Gets star rank and saves 
  public void Result()
  {
    if (LevelManager.instance.isLevelCompleted)
    {
      print("Level complete with a rank of " + LevelManager.instance.GetStarRank());
      //index 0 in list is level1...
      if (CurrentPlayerData.instance.levels.Count > GameManager.instance.currentLevelNumber
        && CurrentPlayerData.instance.levels[GameManager.instance.currentLevelNumber - 1] > 1)
      {

      }
      else
      {
        //For latest level progression
        if (CurrentPlayerData.instance.levels.Count == GameManager.instance.currentLevelNumber)
        {
          CurrentPlayerData.instance.levels.Add(1);

          //Score is higher this time
          if (CurrentPlayerData.instance.levels[GameManager.instance.currentLevelNumber - 1]
            < LevelManager.instance.GetStarRank())
          {
            CurrentPlayerData.instance.levels[GameManager.instance.currentLevelNumber - 1] = LevelManager
              .instance.GetStarRank();
          }
        }
        //For previous level, trying to replay for a higher star rating
        else
        {
          if (CurrentPlayerData.instance.levels[GameManager.instance.currentLevelNumber - 1]
            < LevelManager.instance.GetStarRank())
          {
            CurrentPlayerData.instance.levels[GameManager.instance.currentLevelNumber - 1] = LevelManager
              .instance.GetStarRank();
          }
        }

        SaveLoad.instance.Save();
      }
    }
    else
    {
      print("Better luck next time");
    }
  }

  //Callback for NextLevelButton
  public void OnNextLevel()
  {
    int currentLevelInt = GameManager.instance.currentLevelNumber;
    int nextLevelInt = currentLevelInt += 1;
    string nextLevel = "Level" + nextLevelInt.ToString();

    GameManager.instance.currentLevelName = nextLevel;

    GameManager.instance.ChangeScene(nextLevel);
  }

  public void NextLevel()
  {
    GameObject gameOverCanvas = GameObject.FindGameObjectWithTag("GameOverCanvas");
    int childCountGameOverCanvas = gameOverCanvas.transform.childCount;

    for (int i = 0; i < childCountGameOverCanvas; i++)
    {
      if (gameOverCanvas.transform.GetChild(i).name == "NextLevelButton")
      {
        GameObject go = gameOverCanvas.transform.GetChild(i).gameObject;
        EventTrigger eventTrigger = go.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;

        entry.callback.AddListener((eventData) => OnNextLevel());
        eventTrigger.triggers.Add(entry);

        return;
      }
    }
  }

  public void GameOver()
  {
    Instantiate(gameOverCanvas);
  }

}
