using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip ExplosionSound;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void PlayExplosionSound()
    {
        _audioSource.PlayOneShot(ExplosionSound);
    }
}
