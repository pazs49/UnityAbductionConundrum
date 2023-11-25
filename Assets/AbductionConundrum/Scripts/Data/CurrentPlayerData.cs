using System.Collections.Generic;
using UnityEngine;

public class CurrentPlayerData : MonoBehaviour
{
  public static CurrentPlayerData instance;

  public List<int> levels;
  public int gold;

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

  public void Load()
  {
    PlayerData playerData = SaveLoad.instance.Load();

    if (playerData.levels.Count == 0)
    {
      playerData.levels.Add(1);
    }

    levels = playerData.levels;
    gold = playerData.gold;
  }
}
