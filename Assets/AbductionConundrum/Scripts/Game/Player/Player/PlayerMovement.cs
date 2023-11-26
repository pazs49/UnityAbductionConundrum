using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public float speed;

  [HideInInspector]
  public PlayerAnimation anim;
  [HideInInspector]
  public Rigidbody2D rb2d;
  [HideInInspector]
  public BoxCollider2D bc2d;
  [HideInInspector]
  public PlayerJump pJump;
  [HideInInspector]
  public PlayerAttack pAttack;
  [HideInInspector]
  public PlayerDeath pDeath;
  [SerializeField]
  int direction;

  //isLeftt and isRightt is a gate to keep the code from firing every frame
  //The code is for nudging the position whenever the player change position.
  //It's to prevent player from moving up ledges accidentally when changing direction
  bool isLeftt;
  bool isRightt;
  public void Run(bool isLeft)
  {
    anim.RunAnim(true);
    direction = isLeft ? -1 : 1;
    if (direction == -1)
    {
      transform.localScale = new Vector3(-1, 1, 1);

      isRightt = true;
      if (isLeftt)
      {
        transform.position -= new Vector3(.05f, 0, 0);
      }
      isLeftt = false;
    }
    else if (direction == 1)
    {
      transform.localScale = new Vector3(1, 1, 1);

      isLeftt = true;
      if (isRightt)
      {
        transform.position += new Vector3(.05f, 0, 0);
      }
      isRightt = false;
    }
  }

  public void Jump()
  {
    pJump.Jump();
    anim.JumpAnim(true);
  }

  public void Idle()
  {
    anim.IdleAnim();
    direction = 0;
  }

  public void Shoot1()
  {
    pAttack.Shoot1();
  }

  public void Death()
  {
    if (!pDeath.isPlayerDead)
    {
      pDeath.Death();
      pDeath.isPlayerDead = true;
    }

  }

  public void Movement()
  {
    //Run
    if (rb2d.bodyType != RigidbodyType2D.Static)
      rb2d.velocity = new Vector2(direction * speed, rb2d.velocity.y);

    //Jump
    if (pJump.isGrounded)
    {
      anim.JumpAnim(false);
    }
    else
    {
      anim.JumpAnim(true);
    }
  }

  public void KeyboardControl()
  {
    if (GameManager.instance.isKeyboardEnabled)
    {
      if (Input.GetKey(KeyCode.A))
      {
        Run(true);
      }
      else if (Input.GetKey(KeyCode.D))
      {
        Run(false);
      }
      else
      {
        Idle();
      }

      if (Input.GetKey(KeyCode.Space))
      {
        Jump();
      }

      if (Input.GetKeyDown(KeyCode.K))
      {
        Shoot1();
      }
    }
  }

  //SFX
  public void PlaySFX(string name)
  {
    AudioManager.instance.PlaySFX(name);
  }

  private void Awake()
  {
    anim = GetComponent<PlayerAnimation>();
    rb2d = GetComponent<Rigidbody2D>();
    bc2d = GetComponent<BoxCollider2D>();
    pJump = GetComponent<PlayerJump>();
    pAttack = GetComponent<PlayerAttack>();
    pDeath = GetComponent<PlayerDeath>();
  }

  private void Update()
  {
#if UNITY_STANDALONE_WIN || UNITY_EDITOR
    KeyboardControl();
#endif
  }
  private void FixedUpdate()
  {
    Movement();
  }

  //Death collisions
  private void OnTriggerEnter2D(Collider2D collision)
  {
    //Checking if player is hit by a collider
    if (collision.transform.parent != null && collision.gameObject.transform.parent.GetComponent<Projectile>() != null
      && collision.gameObject.transform.parent.GetComponent<Projectile>().source == "enemy")
    {
      LevelManager.instance.GameOver(true);
    }
  }
}
