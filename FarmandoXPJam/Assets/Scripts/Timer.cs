using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float timerMaxSeconds = 10;
    float timerValue;
    float fillAmountTime = 1;
    void Start()
    {
        timerValue = timerMaxSeconds;
    }

    public void SetTimerMaxSeconds(float value)
    {
        timerMaxSeconds = value;
    }

    void Update()
    {
        timerValue -= Time.deltaTime;
        UpdateFillAmountTime();
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
}
