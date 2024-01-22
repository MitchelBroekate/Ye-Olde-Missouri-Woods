using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public ChaseState chaseState;
    public bool canSeePlayer;

    [Header("EnemyType")]
    [SerializeField]
    private bool isMelee;
    [SerializeField]
    private bool isRanged;

    [Header("Atributes")]
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private Transform[] patrolPoints;
    private int currentPoint;
    [SerializeField]
    private float movementSpeed;
    private float rotationSpeed = 1.5f;
    private Transform target;

    private void Start()
    {
        currentPoint = 0;
        target = GameObject.Find("OVRCameraRig").transform;
    }

    private void Update()
    {
        bool isDead = enemy.GetComponent<EnemyBehavior>().isEnemyDead;

        if (isDead == false)
        {
            PatrolRoute();
            CheckPlayerDistance();
        }
    }

    void PatrolRoute()
    {
        float distanceToPoint = Vector3.Distance(enemy.transform.position, patrolPoints[currentPoint].position);

        if (distanceToPoint >= 1f && canSeePlayer == false)
        {
            Vector3 dir = patrolPoints[currentPoint].position - enemy.transform.position;
            Quaternion rotation = Quaternion.Slerp(enemy.transform.rotation, Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);
            rotation.x = 0;
            rotation.z = 0;
            enemy.transform.rotation = rotation;
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

        if (isMelee == true)
        {
            if (distanceToPlayer <= 5f)
            {
                canSeePlayer = true;
            }
        }

        if (isRanged == true)
        {
            if (distanceToPlayer <= 5f)
            {
                canSeePlayer = true;
            }
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
