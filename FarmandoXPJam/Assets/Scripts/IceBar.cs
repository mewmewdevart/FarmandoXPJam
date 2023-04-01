using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IceBar : MonoBehaviour
{
    Image image;
    [SerializeField] Sprite[] sprites;
    [SerializeField] Timer timer;
    int spriteIndex;

    void Awake() 
    {
        image = GetComponent<Image>();
    }
    void Start()
    {
        spriteIndex = 0;
        InvokeRepeating("ChooseSprite", 0.1f, 0.2f);
    }

    void Update()
    {
        image.fillAmount = timer.GetFillAmountTime();
    }

    void ChooseSprite()
    {
        image.sprite = sprites[spriteIndex];
        spriteIndex++;
        if (spriteIndex == sprites.Length)
        {
            spriteIndex = 0;
        }
    }
}
