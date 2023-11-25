using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
  public static SaveLoad instance;

  PlayerData playerData;

  string savePath;

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

    savePath = Application.persistentDataPath + "/playerData.json";
  }

  public void Save()
  {
    List<int> levels = CurrentPlayerData.instance.levels;
    int gold = CurrentPlayerData.instance.gold;

    playerData = new PlayerData(levels, gold);

    string json = JsonUtility.ToJson(playerData);
    File.WriteAllText(savePath, json);
  }

  public PlayerData Load()
  {
    if (File.Exists(savePath))
    {
      string json = File.ReadAllText(savePath);
      playerData = JsonUtility.FromJson<PlayerData>(json);
    }
    else
    {
      playerData = new PlayerData(new List<int>(), 0);
    }

    return playerData;
  }
}
