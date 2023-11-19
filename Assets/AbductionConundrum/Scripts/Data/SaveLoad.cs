using System.Collections.Generic;
using System.IO;
using TMPro;
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

    print("Game saved!");
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

    print("Save file loaded!");
    return playerData;
  }

  //Remove on final build
  public void SaveTest()
  {
    CurrentPlayerData.instance.gold += 100;

    Save();
    GameObject.Find("SaveButton(FOR TESTING)").transform.GetChild(0)
      .transform.GetComponent<TextMeshProUGUI>().text = CurrentPlayerData.instance.gold.ToString();
    print("SaveTest Successful!");

  }
}