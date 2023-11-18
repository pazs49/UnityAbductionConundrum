using UnityEngine;

public class MovingPlatform : MonoBehaviour, IActivatable
{
  public bool isActive;

  public Transform[] waypoints;
  public float speed = 2f;

  private int currentWaypointIndex = 0;

  private void Start()
  {
    UnchildWaypoints();
  }

  void FixedUpdate()
  {
    // Check if there are waypoints
    if (waypoints.Length == 0)
    {
      return;
    }

    if (isActive)
    {
      MoveTowardsWaypoint();
    }
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("Player"))
    {
      print("Player detected!");
      collision.gameObject.transform.parent = this.transform;
    }
  }

  private void OnCollisionExit2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("Player"))
    {
      print("Player exiting!");
      collision.gameObject.transform.parent = null;
    }
  }

  void MoveTowardsWaypoint()
  {
    Transform currentWaypoint = waypoints[currentWaypointIndex];

    transform.position = Vector2.MoveTowards(transform.position, currentWaypoint.position, speed * Time.deltaTime);

    if (Vector2.Distance(transform.position, currentWaypoint.position) < 0.1f)
    {
      currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
    }
  }

  //So it wouldn't be infinite movement LOL
  void UnchildWaypoints()
  {
    foreach (Transform tform in waypoints)
    {
      tform.parent = null;
    }
  }

  public void Switch()
  {
    isActive = !isActive;
  }
}
