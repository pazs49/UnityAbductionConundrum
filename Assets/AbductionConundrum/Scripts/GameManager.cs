using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class GameManager : MonoBehaviour
{
  public GameObject levelManager;

  public static GameManager instance;

  //mainMenu, game
  public string currentState;

  public List<Level> levels;
  public string currentLevelName;
  public int currentLevelNumber;

  public bool isKeyboardEnabled;

  //Fading in and fading out when level starts
  public GameObject transitionCanvas;
  public List<string> scenesLoaded;

  private void OnEnable()
  {
    SceneManager.sceneLoaded += OnSceneLoaded;
  }

  private void OnDisable()
  {
    SceneManager.sceneLoaded -= OnSceneLoaded;
  }

  private void Awake()
  {
    if (instance != null)
    {
      Destroy(gameObject);
    }
    else
    {
      instance = this;
    }
  }

  private void Start()
  {
    DontDestroyOnLoad(gameObject);
    LoadSave();
  }

  public void LoadSave()
  {
    CurrentPlayerData.instance.Load();
  }

  public void SaveData()
  {
    SaveLoad.instance.Save();
  }

  public void ChangeState(string state)
  {
    currentState = state;
  }

  public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
  {
    scenesLoaded.Add(SceneManager.GetActiveScene().name);

    if (currentState == "game")
    {
      AudioManager.instance.PlayMusic("Game2");
      Instantiate(levelManager);
      GetCurrentLevelData();

      Transition("fadeout");
    }
    else if (currentState == "mainMenu")
    {
      AudioManager.instance.PlayMusic("MainMenu");
      Transition("fadeout");
    }
  }

  public void ChangeScene(string sceneName)
  {
    SceneManager.LoadScene(sceneName);
  }

  public Level GetCurrentLevelData()
  {
    currentLevelNumber = int.Parse(Regex.Match(currentLevelName, @"\d+").Value);
    Level currentLevel = levels[currentLevelNumber - 1];

    return currentLevel;
  }

  public void NewLevel(string levelName)
  {

  }

  /// <summary>
  /// fadein, fadeout, complete
  /// </summary>
  /// <param name="fadeType"></param>
  public void Transition(string fadeType)
  {
    GameObject go = Instantiate(GameManager.instance.transitionCanvas);

    if (fadeType == "fadein")
    {
      go.GetComponent<Transition>().fadeType = "fadein";
    }
    else if (fadeType == "fadeout")
    {
      go.GetComponent<Transition>().fadeType = "fadeout";
    }
    else if (fadeType == "complete")
    {
      go.GetComponent<Transition>().fadeType = "complete";
    }
  }

  public string GetPreviousSceneName()
  {
    if (scenesLoaded.Count >= 2)
    {
      return scenesLoaded[scenesLoaded.Count - 1];
    }
    else
    {
      return "MainMenu";
    }
  }

  public bool IsLastSceneALevel()
  {
    bool isLastSceneALevel = Regex.IsMatch(GetPreviousSceneName(), @"\bLevel\b");

    return isLastSceneALevel;
  }
}
