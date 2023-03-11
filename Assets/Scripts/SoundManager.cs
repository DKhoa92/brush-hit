using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource, effectSource;
    [SerializeField] private AudioClip musicClip, effectClip;

    public static SoundManager Instance{get; private set;}
    private void Awake() 
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        } else {
            Instance = this;
        }
    }

    public void PlayPopSoundEffect()
    {
        effectSource.PlayOneShot(effectClip);
    }
}
