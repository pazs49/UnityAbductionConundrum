using UnityEngine;

public class Gate : MonoBehaviour, IActivatable
{
  public GameObject gate;

  public bool isActive;
  public float openingWidth;
  public float closingWidth = 0;
  public float moveSpeed;

  private void Awake()
  {
    openingWidth = gate.transform.localPosition.y + openingWidth;
  }

  private void FixedUpdate()
  {
    Effect();
  }

  public void Switch()
  {
    //print("Got Activated by switch");
    Toggle();
  }

  public void Toggle()
  {
    isActive = !isActive;
  }

  public void Effect()
  {
    Vector3 currentPosition = gate.transform.localPosition;
    if (isActive && currentPosition.y < openingWidth)
    {
      //print("Going up");
      float newYPosition = currentPosition.y + moveSpeed * Time.fixedDeltaTime;
      gate.transform.localPosition = new Vector3(gate.transform.localPosition.x, newYPosition, gate.transform.localPosition.z);
    }
    else if (!isActive && currentPosition.y >= closingWidth)
    {
      //print("Going down");
      float newYPosition = currentPosition.y - moveSpeed * Time.fixedDeltaTime;
      gate.transform.localPosition = new Vector3(gate.transform.localPosition.x, newYPosition, gate.transform.localPosition.z);
    }
  }
}
