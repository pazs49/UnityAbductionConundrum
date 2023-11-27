using UnityEngine;

public class ButtonSwitch : MonoBehaviour
{
  public GameObject[] activatables;

  public GameObject cap;

  public bool isActivated;

  float moveSpeed = 2.0f;
  float moveDistance = 0.06f;

  void Update()
  {
    if (isActivated)
      MoveDownOverTime();
  }


  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Projectile"))
    {
      isActivated = true;
    }
  }

  void Activate()
  {
    AudioManager.instance.PlaySFX("activate");
    isActivated = true;
    if (activatables.Length >= 1)
    {
      foreach (GameObject go in activatables)
      {
        IActivatable iActivatable = go.GetComponent<IActivatable>();
        iActivatable.Switch();
      }
    }
  }

  void MoveDownOverTime()
  {
    if (moveDistance > 0.0f)
    {
      float distancePerFrame = moveSpeed * Time.deltaTime;
      Vector3 localMove = new Vector3(0.0f, -distancePerFrame, 0.0f);

      cap.transform.Translate(localMove, Space.Self);

      moveDistance -= distancePerFrame;

      if (moveDistance <= 0.0f)
      {
        cap.transform.Translate(new Vector3(0.0f, -moveDistance, 0.0f), Space.Self);
        Activate();
      }
    }
  }
}
