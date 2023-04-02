using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float timerMaxSeconds = 10;
    float timerValue;
    float fillAmountTime = 1;
    bool runningTimer;
    void Start()
    {
        runningTimer = true;
        timerValue = timerMaxSeconds;
    }

    public void SetTimerMaxSeconds(float value)
    {
        timerMaxSeconds = value;
    }

    void Update()
    {
        if (runningTimer)
        {
            timerValue -= Time.deltaTime;
            UpdateFillAmountTime();
        }
    }

    void UpdateFillAmountTime()
    {
        fillAmountTime = timerValue / timerMaxSeconds;
    }

    public float GetFillAmountTime()
    {
        return fillAmountTime;
    }

    public void RecoverFillAmountTime()
    {
        timerValue = timerMaxSeconds;
    }

    public void StopRunningTimer()
    {
        runningTimer = false;
    }
}
