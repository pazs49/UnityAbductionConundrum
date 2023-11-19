using UnityEngine;
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

  public void Skip()
  {
    print("Level skipped and watched an unskippable ad!");
  }

  public void Retry()
  {
    string currentSceneName = SceneManager.GetActiveScene().name;
    GameManager.instance.ChangeScene(currentSceneName);
  }

  public void MainMenu()
  {
    GameManager.instance.ChangeState("mainMenu");
    GameManager.instance.ChangeScene("MainMenu");
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
      //Dead but next level is already completed so we can go next level
    }
  }

  public void NextLevel()
  {
    int currentLevelInt = GameManager.instance.currentLevelNumber;
    int nextLevelInt = currentLevelInt += 1;
    string nextLevel = "Level" + nextLevelInt.ToString();

    GameManager.instance.currentLevelName = nextLevel;

    GameManager.instance.ChangeScene(nextLevel);
  }

  public void GameOver(bool isPlayerDead)
  {
    GameObject player = GameObject.FindGameObjectWithTag("Player");
    //Level Incomplete because player is dead
    if (isPlayerDead)
    {
      print("Game over pDead");
      player.GetComponent<PlayerMovement>().Death();
      isLevelCompleted = false;
      Instantiate(gameOverCanvas);
    }
    //Level Complete because player is alive
    else
    {
      print("Game over pAlive");
      isLevelCompleted = true;
      Instantiate(gameOverCanvas);
    }

  }

}
