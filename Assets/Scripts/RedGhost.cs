using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RedGhost : MonoBehaviour
{
    public Transform playerPositionTransform;
    public NavMeshAgent navMeshAgent;
    float timer = 0;
    float checkTimer = 0;

    void Awake()
    {
    }

    void Update()
    {
        if (timer > 5)
        {
            if (checkTimer > 1)
            {
                navMeshAgent.destination = playerPositionTransform.position;
                checkTimer = 0;
            }
        }

        timer += Time.deltaTime;
        checkTimer += Time.deltaTime;
    }
}
