using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
  public static AudioManager instance;

  public Sound[] musicSounds, sfxSounds;
  public AudioSource musicSource, sfxSource;

  private void Awake()
  {
    if (instance != null)
    {
      Destroy(gameObject);
    }
    else
    {
      instance = this;
    }
  }

  private void Start()
  {
    PlayMusic("MainMenu");
  }

  public void PlayMusic(string name)
  {
    Sound s = Array.Find(musicSounds, x => x.name == name);
    if (s != null)
    {
      musicSource.clip = s.clip;
      musicSource.Play();
    }
  }

  public void PlaySFX(string name, float specificTime = 0)
  {
    Sound s = Array.Find(sfxSounds, x => x.name == name);
    if (s != null)
    {
      sfxSource.PlayOneShot(s.clip);
    }
  }
}
