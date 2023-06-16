using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OrangeGhost : MonoBehaviour
{
    public Transform playerPositionTransform;
    public NavMeshAgent navMeshAgent;
    public PlayerMovement player;
    public float distance;
    float timer = 0;
    float checkTimer = 0;
    float randomizeTimer = 0;
    Vector3 targetPos = Vector3.zero;
    bool previousSighted = false;
    bool notRandomized = false;

    void Awake()
    {
        RandomizeLocation();
    }

    void Update()
    {
        if (timer > 5)
        {

            // Debug.Log("Target Direction: " + player.targetDirection);
            // Debug.Log("Hit Pos: " + hit.position);
            Debug.Log("Complete: " + (navMeshAgent.pathStatus == NavMeshPathStatus.PathComplete));
            if ((randomizeTimer > 15 || navMeshAgent.pathStatus == NavMeshPathStatus.PathComplete) && notRandomized)
            {
                RandomizeLocation();
                randomizeTimer = 0;
                notRandomized = false;
            }

            if (checkTimer > 1)
            { 
                NavMeshHit hit;
                NavMesh.SamplePosition(targetPos, out hit, distance * 1.5f, NavMesh.AllAreas);
                targetPos = hit.position;
                if (checkLineOfSight())
                {
                    targetPos = playerPositionTransform.position;
                    previousSighted = true;
                }

                if (previousSighted)
                {
                    RandomizeLocation();
                    previousSighted = false;
                }

                navMeshAgent.destination = targetPos;
                checkTimer = 0;

                notRandomized = true;
            }
        }

        timer += Time.deltaTime;
        checkTimer += Time.deltaTime;
        randomizeTimer += Time.deltaTime;
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

    void RandomizeLocation()
    {
        targetPos = new Vector3(Random.Range(-40f, 40f), playerPositionTransform.position.y, Random.Range(-40f, 40f));
        Debug.Log("Target Pos: " + targetPos);
    }
}
