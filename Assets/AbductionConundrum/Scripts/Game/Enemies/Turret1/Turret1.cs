using UnityEngine;

public class Turret1 : MonoBehaviour, IEnemy
{
  [field: SerializeField]
  public State currentState { get; set; }

  [field: SerializeField]
  public bool IsActive { get; set; }
  [field: SerializeField]
  public GameObject DeathEffect { get; set; }
  [field: SerializeField]
  public float Health { get; set; }
  [field: SerializeField]
  public float AttackInterval { get; set; }
  [field: SerializeField]
  public float AttackPower { get; set; }

  [Space(10)]

  public GameObject projectile;
  public GameObject spawnPoint;

  Animator anim;

  float timer;


  private void OnTriggerEnter2D(Collider2D collision)
  {
    //Hit by player's projectile
    if (collision.transform.parent && collision.transform.parent.GetComponent<Projectile>()
      && collision.transform.parent.GetComponent<Projectile>().source == "player")
    {
      State(global::State.Dead);
    }
  }

  private void Awake()
  {
    anim = GetComponent<Animator>();
  }

  private void Start()
  {
    currentState = global::State.Attacking;
  }

  private void Update()
  {
    //Timings
    if (currentState == global::State.Idle)
    {
      State(currentState);
    }
    else if (currentState == global::State.Attacking)
    {
      if (IsActive)
      {
        timer += Time.deltaTime;
        while (AttackInterval <= timer)
        {
          State(currentState);
          timer = 0;
        }
      }
      else if (!IsActive)
      {
        State(global::State.Idle);
      }
    }
    else if (currentState == global::State.Dead)
    {
      State(currentState);
    }
  }

  public void State(State currentState)
  {
    switch (currentState)
    {
      case global::State.Idle:
        //anim.SetTrigger("idle");
        Idle();
        break;

      case global::State.Attacking:
        anim.SetTrigger("attack");
        Attack();
        break;

      case global::State.Dead:
        Death();
        break;

      default:
        break;
    }
  }

  public void Attack()
  {
    int direction = transform.localScale.x == 1 ? 1 : -1;
    GameObject mProjectile = Instantiate(projectile, spawnPoint.transform.position, Quaternion.identity);
    mProjectile.GetComponent<Rigidbody2D>().AddForce((transform.right * direction) * AttackPower, ForceMode2D.Impulse);
    mProjectile.GetComponent<Projectile>().source = "enemy";
    currentState = global::State.Idle;
  }

  public void Idle()
  {
    currentState = global::State.Attacking;
  }

  public void Death()
  {
    Instantiate(DeathEffect, new Vector3(transform.position.x, transform.position.y, 10), Quaternion.identity);
    Destroy(gameObject);
  }
}
