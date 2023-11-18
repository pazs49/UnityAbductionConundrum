using UnityEngine;

public class CameraFollow : MonoBehaviour
{
  public Transform target; // Reference to the player's transform
  public float smoothSpeed = 0.125f; // Adjust this to control the camera follow speed
  public Vector2 offset; // Offset from the player (X and Y)

  private Vector3 velocity = Vector3.zero;

  void FixedUpdate()
  {
    if (target != null)
    {
      Vector3 desiredPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);
      Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
      transform.position = smoothedPosition;
    }
  }
}
