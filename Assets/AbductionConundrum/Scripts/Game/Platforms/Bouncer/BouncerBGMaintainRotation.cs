using UnityEngine;

public class BouncerBGMaintainRotation : MonoBehaviour
{
  Quaternion InitRot;

  void Start()
  {
    InitRot = transform.rotation;
  }
  void LateUpdate()
  {
    if (gameObject.transform.parent != null)
    {
      transform.rotation = InitRot;
    }
  }
}
