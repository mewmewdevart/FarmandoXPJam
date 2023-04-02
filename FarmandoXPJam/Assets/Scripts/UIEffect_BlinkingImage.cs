using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEffect_BlinkingImage : MonoBehaviour {

    public float blinkTime = 0.5f;

    IEnumerator Blink() {
        while (true) {
            GetComponent<Image>().enabled = false;
            yield return new WaitForSeconds(blinkTime);
            GetComponent<Image>().enabled = true;
            yield return new WaitForSeconds(blinkTime);
        }
    }

    void Start() {
        StartCoroutine(Blink());
    }
}

