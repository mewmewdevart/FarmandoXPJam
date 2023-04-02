using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UPDOWNMovingPlatform : MonoBehaviour
{
    [SerializeField] Vector3 startPosition;
    [SerializeField] Vector3 targetPosition;
    [Range(0f, 0.09f)][SerializeField] float velocity;
    Vector3 realTarget;
    void Start()
    {
        transform.position = startPosition;
        realTarget = targetPosition;
    }

    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, targetPosition) <= 0.01f)
        {
            realTarget = startPosition;
        }
        else if (Vector2.Distance(transform.position, startPosition) <= 0.01f)
        {
            realTarget = targetPosition;
        }
        Move(realTarget);
    }

    void Move(Vector3 target)
    {
        Vector3 a = transform.position;
        
        transform.position = Vector3.MoveTowards(a, target, velocity);
    }
}
