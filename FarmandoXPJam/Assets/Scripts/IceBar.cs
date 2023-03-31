using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IceBar : MonoBehaviour
{
    Image image;
    [SerializeField] Timer timer;

    void Awake() 
    {
        image = GetComponent<Image>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        image.fillAmount = timer.GetFillAmountTime();
    }
}
