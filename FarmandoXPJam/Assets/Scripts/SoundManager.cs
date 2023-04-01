using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;
    [Header("Movements")]
    [SerializeField] AudioClip walkClip;
    [SerializeField] AudioClip jumpClip;
    

    void Awake() 
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayWalkClip()
    {
        if (!audioSource.isPlaying)
        {
            PlayClip(walkClip);
        }
    }

    public void StopAudio()
    {
        audioSource.Stop();
    }

    public void PlayJumpClip()
    {
        PlayClip(jumpClip);
    }
    
    void PlayClip(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
