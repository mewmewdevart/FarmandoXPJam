using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    int points;
    [SerializeField] TextMeshProUGUI textPoints; 


    void Start()
    {
        points = 0;
    }

    void Update()
    {
        textPoints.text = $"Points: {points}";
    }

    public void AddPoints(int value)
    {
        points += value;
    }
}
