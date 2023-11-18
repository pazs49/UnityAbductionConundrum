using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class GameManager : MonoBehaviour
{
  //mainMenu, game
  [SerializeField]
  string currentState;

  public GameObject levelManager;

  public static GameManager instance;

  public List<Level> levels;
  public string currentLevelName;
  public int currentLevelNumber;

  public bool isKeyboardEnabled;

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
    if (currentState == "game")
    {
      Instantiate(levelManager);
      GetCurrentLevelData();
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
}
