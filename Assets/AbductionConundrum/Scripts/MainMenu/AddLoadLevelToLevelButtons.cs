using UnityEngine;
using UnityEngine.EventSystems;

public class AddLoadLevelToLevelButtons : MonoBehaviour
{
  public string levelName;

  private void Awake()
  {
    AddLoadLevelFuncToEventTriggerPointerDown();
  }

  void LoadLevel()
  {
    GameManager.instance.Transition("fadein");
    Invoke("LoadLevelWithDelay", .5f);
  }

  //Give way to transition animation
  void LoadLevelWithDelay()
  {
    GameManager.instance.ChangeState("game");
    GameManager.instance.currentLevelName = levelName;
    GameManager.instance.ChangeScene(levelName);
  }

  void AddLoadLevelFuncToEventTriggerPointerDown()
  {
    EventTrigger eventTrigger = GetComponent<EventTrigger>();
    EventTrigger.Entry entry = new EventTrigger.Entry();
    entry.eventID = EventTriggerType.PointerClick;

    entry.callback.AddListener((eventData) => LoadLevel());
    eventTrigger.triggers.Add(entry);
  }
}
