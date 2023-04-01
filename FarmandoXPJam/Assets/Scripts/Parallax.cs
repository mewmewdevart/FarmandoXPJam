using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] float moveFactor;
    [SerializeField] Transform cam;
    [SerializeField] bool lockY = false; 

    void Update()
    {
        if (lockY)
        {
            transform.position = new Vector2(cam.position.x * moveFactor, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(cam.position.x * moveFactor, cam.position.y * moveFactor);
        }
    }
}
