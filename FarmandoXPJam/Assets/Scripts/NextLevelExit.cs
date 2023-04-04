using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelExit : MonoBehaviour
{
    Animator myAnimator;
    [SerializeField] Timer timer;
    [SerializeField] float levelLoadDelay = 1f;
    SoundManager soundManager;

    void Awake() 
    {
        myAnimator = gameObject.GetComponent<Animator>();
        soundManager = FindAnyObjectByType<SoundManager>();
    }
    void Start() 
    {
        
    }
    void OnTriggerEnter2D()
    {
        myAnimator.SetTrigger("HasEscaped");
        timer.StopRunningTimer();
        soundManager.PlayExitDoor();
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevel + 1);
    }
}
