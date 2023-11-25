using UnityEngine;

public class Transition : MonoBehaviour
{
  public Animator anim;
  public string fadeType;

  public void Start()
  {
    if (fadeType == "fadein")
    {
      anim.SetBool("isFading", true);
    }
    else if (fadeType == "fadeout")
    {
      anim.SetBool("isFading", false);
    }
    else if (fadeType == "complete")
    {
      //anim.SetBool("isFading", true);
    }
  }
}
