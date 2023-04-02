using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;
    [Header("Movements")]
    [SerializeField] AudioClip walkClip;
    [SerializeField] AudioClip jumpClip;
    [Header("Items")]
    [SerializeField] AudioClip snowPieceClip;
    [Header("Evolutions")]
    [SerializeField] AudioClip shrinkClip;
    [SerializeField] AudioClip growClip;
    

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

    public void PlaySnowPieceClip()
    {
        AudioSource.PlayClipAtPoint(snowPieceClip, Camera.main.transform.position);
    }

    public void PlayGrowClip()
    {
        AudioSource.PlayClipAtPoint(growClip, Camera.main.transform.position);
    }

    public void PlayShrinkClip()
    {
        AudioSource.PlayClipAtPoint(shrinkClip, Camera.main.transform.position);
    }
    
    void PlayClip(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
