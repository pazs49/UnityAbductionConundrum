using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Put this in the Play to automatically load the levels, just place the scriptableobjects
public class PlayLoadLevelsAndGenerate : MonoBehaviour
{
  public List<Level> levels;

  public GameObject level;

  private void Start()
  {
    //levels are passed to game manager because it has dontdestroyonload
    GameManager.instance.levels = levels;
    LoadAndGenerate();
  }

  void LoadAndGenerate()
  {
    for (int i = 0; i < levels.Count; i++)
    {
      GameObject go = Instantiate(level, this.transform);
      bool isLocked = true;

      go.AddComponent<AddLoadLevelToLevelButtons>();
      AddLoadLevelToLevelButtons playLevel = go.GetComponent<AddLoadLevelToLevelButtons>();
      playLevel.levelName = levels[i].name;

      //Disable all stars
      go.transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(false);
      go.transform.GetChild(1).transform.GetChild(1).gameObject.SetActive(false);
      go.transform.GetChild(1).transform.GetChild(2).gameObject.SetActive(false);

      //Check if level is unlocked
      if (CurrentPlayerData.instance.levels.Count > i)
      {
        if (CurrentPlayerData.instance.levels[i] >= 1)
        {
          isLocked = false;
          //LockImage gameobject
          go.transform.GetChild(2).gameObject.SetActive(false);

          //Load star rank
          for (int j = 0; j < CurrentPlayerData.instance.levels[i]; j++)
          {
            go.transform.GetChild(1).transform.GetChild(j).gameObject.SetActive(true);
          }
        }
      }
      if (isLocked)
      {
        //Remove Load level if level is locked
        go.GetComponent<EventTrigger>().triggers.Clear();

        Color color = new Color32(255, 212, 186, 255);
        go.GetComponent<Image>().color = color;
      }

      //Name
      TextMeshProUGUI text = go.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
      text.text = (i + 1).ToString();
    }
  }
}
