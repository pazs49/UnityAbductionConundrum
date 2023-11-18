using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
  Animator animator;

  public void RunAnim(bool state)
  {
    animator.SetBool("isRunning", state);
  }
  public void IdleAnim()
  {
    animator.SetBool("isRunning", false);
  }
  public void JumpAnim(bool enable)
  {
    animator.SetBool("isJumping", enable);
  }
  public void ShootAnim()
  {
    animator.SetTrigger("shoot");
  }
  private void Awake()
  {
    animator = GetComponent<Animator>();
  }
}
