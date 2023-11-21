using UnityEngine;

public class Cog : MonoBehaviour
{
  public float rotationSpeed;
  public GameObject[] cogs;

  private void Update()
  {
    Rotate();
  }

  void Rotate()
  {
    cogs[0].transform.Rotate(Vector3.forward, (rotationSpeed * Time.deltaTime) * -1);
    cogs[1].transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
  }
}
