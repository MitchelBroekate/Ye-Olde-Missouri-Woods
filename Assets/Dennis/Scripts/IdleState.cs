using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public ChaseState chaseState;
    public bool canSeePlayer;

    [Header("Atributes")]
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private Transform[] patrolPoints;
    private int currentPoint;
    [SerializeField]
    private float movementSpeed;
    private Transform target;

    private void Start()
    {
        currentPoint = 0;
        target = GameObject.Find("OVRCameraRig").transform;
    }

    private void Update()
    {
        PatrolRoute();
        CheckPlayerDistance();
    }

    void PatrolRoute()
    {
        float distanceToPoint = Vector3.Distance(enemy.transform.position, patrolPoints[currentPoint].position);

        if (distanceToPoint > 0.6f && canSeePlayer == false)
        {
            enemy.transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, movementSpeed * Time.deltaTime);
        }
        else
        {
            currentPoint = (currentPoint + 1) % patrolPoints.Length;
        }
    }

    void CheckPlayerDistance()
    {
        float distanceToPlayer = Vector3.Distance(enemy.transform.position, target.position);

        if (distanceToPlayer < 10f)
        {
            canSeePlayer = true;
        }
    }

    public override State RunCurrentState()
    {
        if (canSeePlayer == true)
        {
            return chaseState;
        }
        else
        {
            return this;
        }
    }
}
