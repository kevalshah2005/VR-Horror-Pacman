using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlueGhost : MonoBehaviour
{
    public Transform playerPositionTransform;
    public Transform blinkyPositionTransform;
    public PlayerMovement player;
    public float distance;
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
                Vector3 intermediatePos = playerPositionTransform.position + player.targetDirection * distance;
                Vector3 targetPos = intermediatePos + (intermediatePos - blinkyPositionTransform.position);

                if (checkLineOfSight())
                {
                    targetPos = playerPositionTransform.position;
                }
                navMeshAgent.destination = targetPos;

                checkTimer = 0;
            }
        }

        timer += Time.deltaTime;
        checkTimer += Time.deltaTime;
    }

    bool checkLineOfSight()
    {
        RaycastHit hit;
        Vector3 raycastDirection = playerPositionTransform.position - transform.position;
        if (Physics.Raycast(transform.position, raycastDirection, out hit))
        {
            return hit.collider.gameObject.tag.Equals("Player");
        }
        return false;
    }
}
