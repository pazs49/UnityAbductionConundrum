using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Game/Level")]
public class Level : ScriptableObject
{
  public int level;
  public int stars;

  private void Awake()
  {
    level = new ExtractNumberFromName(name).Value;
  }
}
