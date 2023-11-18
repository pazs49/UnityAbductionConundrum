using System.Collections.Generic;

public class PlayerData
{
  //0 locked, 1 1star, 2 2star, 3 3star
  public List<int> levels;

  public int gold;


  public PlayerData(List<int> levels, int gold)
  {
    this.levels = levels;
    this.gold = gold;
  }

  public PlayerData(int gold)
  {
    this.gold = gold;
  }
}

