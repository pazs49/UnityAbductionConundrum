using UnityEngine;

public class Rotator : MonoBehaviour
{
  //Touch
  private Touch touch;
  private Vector2 oldTouchPosition;
  private Vector2 newTouchPosition;

  //Mouse
  private Vector2 oldMousePosition;
  private Vector2 newMousePosition;

  Vector2 rotDirection;

  [SerializeField]
  private float keepRotateSpeed = 10f;
  bool isBeingTouched;

  CircleCollider2D ccol;

  private void Awake()
  {
    ccol = GetComponent<CircleCollider2D>();
  }

  public void Rotate()
  {
    //For touch
    if (!GameManager.instance.isKeyboardEnabled)
    {
      if (Input.touchCount > 0)
      {
        touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
          oldTouchPosition = touch.position;
        }

        else if (touch.phase == TouchPhase.Moved)
        {
          newTouchPosition = touch.position;
        }

        rotDirection = oldTouchPosition - newTouchPosition;

        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);
        if (hit.collider != null && hit.collider.gameObject.name == gameObject.name && (touch.phase == TouchPhase.Began))
        {
          isBeingTouched = true;
        }
        else if (touch.phase == TouchPhase.Ended)
        {
          isBeingTouched = false;
        }
      }
    }

    //For mouse/kb
    else if (GameManager.instance.isKeyboardEnabled)
    {
      if (Input.GetMouseButtonDown(0))
      {
        oldMousePosition = Input.mousePosition;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(oldMousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject.name == gameObject.name)
        {
          isBeingTouched = true;
        }
      }
      else if (Input.GetMouseButton(0))
      {
        newMousePosition = Input.mousePosition;
        rotDirection = oldMousePosition - newMousePosition;
      }
      else if (Input.GetMouseButtonUp(0))
      {
        isBeingTouched = false;
      }
    }

    if (isBeingTouched)
    {
      if (rotDirection.x < 0)
      {
        RotateRight();
      }

      else if (rotDirection.x > 0)
      {
        RotateLeft();
      }
    }
  }

  void RotateLeft()
  {
    transform.rotation = Quaternion.Euler(0f, 0f, 1.5f * keepRotateSpeed) * transform.rotation;
  }

  void RotateRight()
  {
    transform.rotation = Quaternion.Euler(0f, 0f, -1.5f * keepRotateSpeed) * transform.rotation;
  }
}
