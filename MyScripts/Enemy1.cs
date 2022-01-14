using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1 : MonoBehaviour
{
    public Transform[] patrolPoints;

    int patrolPointIndex;
    float proximityBeforeChangeDestination = 0.5f;
    NavMeshAgent navMeshAgent;
    Animator animator;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        navMeshAgent.updatePosition = true;
        navMeshAgent.updateRotation = true;
        SetNextDestination();
    }

    void Update()
    {
        animator.SetFloat("Forward", navMeshAgent.desiredVelocity.magnitude, 0.1f, Time.deltaTime);

        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < proximityBeforeChangeDestination)
        {
            SetNextDestination();
        }
    }

    void SetNextDestination()
    {
        navMeshAgent.SetDestination(patrolPoints[patrolPointIndex].position);
        patrolPointIndex = (patrolPointIndex + 1) % patrolPoints.Length;
    }

    void OnCollisionEnter(Collision c)
    {
        var other = c.gameObject;
        if (other.CompareTag("Player"))
        {
            other.SendMessage("Die");
        }
    }
}
