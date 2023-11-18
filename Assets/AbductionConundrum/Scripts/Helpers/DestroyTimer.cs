using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
  public float time;
  private void Start()
  {
    Destroy(gameObject, time);
  }
}
