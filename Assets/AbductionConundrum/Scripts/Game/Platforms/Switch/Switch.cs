using UnityEngine;

public class Switch : MonoBehaviour
{
  public bool isActivated;

  public GameObject[] activatables;

  [SerializeField]
  GameObject handle;



  void Use()
  {
    isActivated = !isActivated;
  }

  public void Effect()
  {
    if (!isActivated)
    {
      handle.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -45));
    }
    else if (isActivated)
    {
      handle.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 45));
    }
    isActivated = !isActivated;
    Activate();
  }

  void Activate()
  {
    if (activatables.Length >= 1)
    {
      foreach (GameObject go in activatables)
      {
        IActivatable iActivatable = go.GetComponent<IActivatable>();
        iActivatable.Switch();
      }
    }

  }
}
