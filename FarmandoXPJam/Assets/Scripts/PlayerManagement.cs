using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayerManagement : MonoBehaviour
{
    [SerializeField] GameObject[] snowmans;
    [SerializeField] CinemachineVirtualCameraBase virtualCamera;
    int snowmanIndex;
    Transform oldPosition;
    bool isDead;
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
        isDead = false;
    }

    void Update()
    {
        if (!isDead)
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
            snowmans[snowmanIndex].GetComponent<DefaultSnowman>().PlayGrowClipOnSM();
            snowmanIndex++;
            ChangePlayer();
        }
    }

    void Shrink()
    {
        if (snowmanIndex == 0)
        {
            isDead = true;
            snowmans[snowmanIndex].GetComponent<Animator>().SetTrigger("isMelting");
            Invoke("Die", 1f);
        }
        else
        {
            oldPosition = snowmans[snowmanIndex].transform;
            snowmans[snowmanIndex].GetComponent<DefaultSnowman>().PlayShrinkClipOnSM();
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
                timer.SetTimerMaxSeconds(defaultComponent.GetTimeToMelt());
                timer.RecoverFillAmountTime();
            }
        }
    }

    void OnJump(InputValue value)
    {
        if (!isDead && value.isPressed)
        {
            snowmans[snowmanIndex].GetComponent<DefaultSnowman>().OnJumpFather(value);
        }
    }

    void OnMove(InputValue value)
    {
        if (!isDead)
        {
            snowmans[snowmanIndex].GetComponent<DefaultSnowman>().OnMoveFather(value);
        }
    }
}
