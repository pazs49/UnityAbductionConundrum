using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
  PlayerMovement pMovement;

  public bool isPlayerDead;
  public GameObject deathParticle;

  private void Awake()
  {
    pMovement = GetComponent<PlayerMovement>();
  }

  public void Death()
  {
    AudioManager.instance.PlaySFX("pDeath");
    isPlayerDead = true;
    Instantiate(deathParticle, transform.position, Quaternion.identity);

    pMovement.rb2d.velocity = Vector2.zero;
    pMovement.rb2d.gravityScale = 0;
    pMovement.rb2d.bodyType = RigidbodyType2D.Static;
    pMovement.bc2d.enabled = false;
    if (transform.GetChild(0).name == "player")
      transform.GetChild(0).gameObject.SetActive(false);
    isPlayerDead = true;
  }
}
