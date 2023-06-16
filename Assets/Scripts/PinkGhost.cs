using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PinkGhost : MonoBehaviour
{
    public Transform playerPositionTransform;
    public NavMeshAgent navMeshAgent;
    public PlayerMovement player;
    public float distance;
    float timer = 0;
    float checkTimer = 0;

    void Awake()
    {
    }

    void Update()
    {
        if (timer > 5)
        {
            
            // Debug.Log("Target Direction: " + player.targetDirection);
            // Debug.Log("Hit Pos: " + hit.position);
            if (checkTimer > 1)
            {
                Vector3 targetPos = playerPositionTransform.position + player.targetDirection * distance;
                NavMeshHit hit;
                NavMesh.SamplePosition(targetPos, out hit, distance * 1.5f, NavMesh.AllAreas);
                targetPos = hit.position;
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
