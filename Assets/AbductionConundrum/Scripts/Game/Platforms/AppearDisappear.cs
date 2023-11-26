using System.Collections;
using UnityEngine;

public class AppearDisappear : MonoBehaviour, IActivatable
{
  public GameObject[] platforms;

  SpriteRenderer[][] sprites;
  Collider2D[][] colliders;
  //isActive = appear, !isActive = disappear
  [Header("isActive = appear, !isActive = disappear")]
  public bool isActive;
  public float fadeDuration;

  private void Start()
  {
    sprites = new SpriteRenderer[platforms.Length][];
    colliders = new Collider2D[platforms.Length][];

    for (int i = 0; i < platforms.Length; i++)
    {
      SpriteRenderer[] platformSprites = platforms[i].GetComponentsInChildren<SpriteRenderer>(true);
      sprites[i] = platformSprites;

      Collider2D[] platformColliders = platforms[i].GetComponentsInChildren<Collider2D>(true);
      colliders[i] = platformColliders;
    }

    //Default
    if (isActive)
    {
      EnableDisableColliders(false);
      for (int i = 0; i < sprites.Length; i++)
      {
        foreach (SpriteRenderer sr in sprites[i])
        {
          Color currentColor = sr.color;
          currentColor.a = 0f;
          sr.color = currentColor;
        }
      }

    }
    else if (!isActive)
    {
      EnableDisableColliders(true);
      for (int i = 0; i < sprites.Length; i++)
      {
        foreach (SpriteRenderer sr in sprites[i])
        {
          Color currentColor = sr.color;
          currentColor.a = 1f;
          sr.color = currentColor;
        }
      }
    }
  }

  public void Switch()
  {
    Effect();
  }

  void Effect()
  {
    if (isActive)
    {
      EnableDisableColliders(true);
      for (int i = 0; i < sprites.Length; i++)
      {
        foreach (SpriteRenderer sr in sprites[i])
        {
          StartCoroutine(FadeSpriteToFullAlpha(sr));
        }
      }

    }
    else if (!isActive)
    {
      EnableDisableColliders(false);
      for (int i = 0; i < sprites.Length; i++)
      {
        foreach (SpriteRenderer sr in sprites[i])
        {
          StartCoroutine(FadeSpriteToZeroAlpha(sr));
        }
      }
    }

    isActive = !isActive;
  }


  IEnumerator FadeSpriteToZeroAlpha(SpriteRenderer sprite)
  {
    Color currentColor = sprite.color;
    currentColor.a = 1f;

    while (currentColor.a > 0f)
    {
      currentColor.a -= Time.deltaTime / fadeDuration;
      sprite.color = currentColor;
      yield return null;
    }

    currentColor.a = 0f;
    sprite.color = currentColor;
  }

  IEnumerator FadeSpriteToFullAlpha(SpriteRenderer sprite)
  {
    Color currentColor = sprite.color;
    currentColor.a = 0f;

    while (currentColor.a < 1f)
    {
      currentColor.a += Time.deltaTime / fadeDuration;
      sprite.color = currentColor;
      yield return null;
    }

    currentColor.a = 1f;
    sprite.color = currentColor;
  }

  void EnableDisableColliders(bool isEnable)
  {
    if (isEnable)
    {
      for (int i = 0; i < colliders.Length; i++)
      {
        foreach (Collider2D col in colliders[i])
        {
          col.enabled = true;
        }
      }
    }
    else if (!isEnable)
    {
      for (int i = 0; i < colliders.Length; i++)
      {
        foreach (Collider2D col in colliders[i])
        {
          col.enabled = false;
        }
      }
    }
  }
}
