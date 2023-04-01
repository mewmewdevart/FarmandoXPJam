using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Nav : MonoBehaviour
{
    NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        Vector3 point = GameObject.FindFirstObjectByType<DefaultSnowman>().transform.position;
        point += new Vector3(-1f, 4f, 0f);
        agent.SetDestination(point);
    }
}
