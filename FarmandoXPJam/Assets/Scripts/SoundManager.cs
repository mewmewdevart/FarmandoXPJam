using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource backgroundMusic;
    [Header("Movements")]
    [SerializeField] AudioClip walkClip;
    [SerializeField] AudioClip jumpClip;
    [Header("Items")]
    [SerializeField] AudioClip snowPieceClip;
    [SerializeField] AudioClip exitDoorClip;
    [Header("Evolutions")]
    [SerializeField] AudioClip shrinkClip;
    [SerializeField] AudioClip growClip;
    [Header("Ost Music")]
    [SerializeField] AudioClip[] levelThemeClip;
    

    void Awake() 
    {
        audioSource = GetComponent<AudioSource>();
        backgroundMusic.clip = levelThemeClip[SceneManager.GetActiveScene().buildIndex];
        backgroundMusic.Play();
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

    public void PlayExitDoor()
    {
        AudioSource.PlayClipAtPoint(exitDoorClip, Camera.main.transform.position);
    }
    
    void PlayClip(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
