using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class PlayerManagement : MonoBehaviour
{
    [SerializeField] GameObject[] snowmans;
    [SerializeField] CinemachineVirtualCameraBase virtualCamera;
    int snowmanIndex;
    Transform oldPosition;

    [SerializeField] Timer timer;

    void Awake()
    {
        snowmans[0].SetActive(false);
        snowmans[1].SetActive(true);
        timer.SetTimerMaxSeconds(snowmans[1].GetComponent<DefaultSnowman>().GetTimeToMelt());
        snowmans[2].SetActive(false);
    }
    void Start()
    {
        snowmanIndex = 1;
    }

    void Update()
    {
        DefaultSnowman defaultComponent = snowmans[snowmanIndex].GetComponent<DefaultSnowman>();
        if (timer.GetFillAmountTime() <= 0)
        {
            Shrink();
        }
        if (defaultComponent.GetIsGrowing())
        {
            defaultComponent.ResetIsGrowing();
            Grow();
        }
    }

    void Grow()
    {
        if (snowmanIndex == 2)
        {
            timer.RecoverFillAmountTime();
        }
        else
        {
            oldPosition = snowmans[snowmanIndex].transform;
            snowmanIndex++;
            ChangePlayer();
        }
    }

    void Shrink()
    {
        if (snowmanIndex == 0)
        {
            Die();
        }
        else
        {
            oldPosition = snowmans[snowmanIndex].transform;
            snowmanIndex--;
            ChangePlayer();
        }
    }

    void Die()
    {
        SceneManager.LoadScene("GameOver");
    }

    void ChangePlayer()
    {
        virtualCamera.Follow = snowmans[snowmanIndex].transform;
        for (int i = 0; i < snowmans.Length; i++)
        {
            DefaultSnowman defaultComponent = snowmans[i].GetComponent<DefaultSnowman>();
            defaultComponent._SetActive(i == snowmanIndex ? true : false, oldPosition);
            if (i == snowmanIndex)
            {
                timer.SetTimerMaxSeconds(snowmans[i].GetComponent<DefaultSnowman>().GetTimeToMelt());
                timer.RecoverFillAmountTime();
            }
        }
    }
}
