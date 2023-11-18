using UnityEngine;

public class SwitchTrigger : MonoBehaviour
{
  public Switch mySwitch;

  private void OnTriggerEnter2D(Collider2D collision)
  {
    int layer = collision.gameObject.layer;
    string layerName = LayerMask.LayerToName(layer);

    if (layerName == "Projectile")
    {
      mySwitch.Effect();
    }
  }
}
