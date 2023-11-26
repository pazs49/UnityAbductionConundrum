using UnityEngine;

public class Powerup : MonoBehaviour
{
  public PowerupType powerup;
  public float value;

  [Space(20)]
  public Sprite powerSprite, jumpSprite;
  public GameObject positiveParticleSystem, negativeParticleSystem;

  public SpriteRenderer sr;

  private void Start()
  {
    if (powerup == PowerupType.PowerPositive)
    {
      sr.sprite = powerSprite;
      positiveParticleSystem.SetActive(true);
      negativeParticleSystem.SetActive(false);
    }
    else if (powerup == PowerupType.PowerNegative)
    {
      sr.sprite = powerSprite;
      negativeParticleSystem.SetActive(true);
      positiveParticleSystem.SetActive(false);
    }
    else if (powerup == PowerupType.JumpPositive)
    {
      sr.sprite = jumpSprite;
      positiveParticleSystem.SetActive(true);
      negativeParticleSystem.SetActive(false);
    }
    else if (powerup == PowerupType.JumpNegative)
    {
      sr.sprite = jumpSprite;
      negativeParticleSystem.SetActive(true);
      positiveParticleSystem.SetActive(false);
    }
  }

  private void Update()
  {
    //This is to hide the particle system with appeardisappear. Appeardisappear only targets sprite renderer and colliders
    if (sr.color.a == 1)
    {
      if (powerup == PowerupType.PowerPositive)
      {
        positiveParticleSystem.SetActive(true);
        negativeParticleSystem.SetActive(false);
      }
      else if (powerup == PowerupType.PowerNegative)
      {
        negativeParticleSystem.SetActive(true);
        positiveParticleSystem.SetActive(false);
      }
      else if (powerup == PowerupType.JumpPositive)
      {
        positiveParticleSystem.SetActive(true);
        negativeParticleSystem.SetActive(false);
      }
      else if (powerup == PowerupType.JumpNegative)
      {
        negativeParticleSystem.SetActive(true);
        positiveParticleSystem.SetActive(false);
      }
    }
    else if (sr.color.a == 0)
    {
      negativeParticleSystem.SetActive(false);
      positiveParticleSystem.SetActive(false);
    }
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag("Player"))
    {
      PlayerJump pJump = collision.GetComponent<PlayerJump>();
      PlayerAttack pAttack = collision.GetComponent<PlayerAttack>();
      switch (powerup)
      {
        case PowerupType.PowerPositive:
          AudioManager.instance.PlaySFX("positive");
          pAttack.shootForce = value;
          break;
        case PowerupType.PowerNegative:
          AudioManager.instance.PlaySFX("negative");
          pAttack.shootForce = value;
          break;
        case PowerupType.JumpPositive:
          AudioManager.instance.PlaySFX("positive");
          pJump.jumpForce = value;
          break;
        case PowerupType.JumpNegative:
          AudioManager.instance.PlaySFX("negative");
          pJump.jumpForce = value;
          break;
      }
    }
  }
}



public enum PowerupType
{
  PowerPositive,
  PowerNegative,
  JumpPositive,
  JumpNegative
}