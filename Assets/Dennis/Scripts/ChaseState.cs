using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : State
{
    public AttackState attackState;
    public bool canAttack;

    [Header("Attributes")]
    [SerializeField]
    private GameObject enemy;
    NavMeshAgent agent;
    Transform target;

    private void Awake()
    {
        agent = enemy.GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        target = GameObject.Find("OVRCameraRig").transform;
    }

    private void Update()
    {
        ChasePlayer();
        InAttackRange();
    }

    void ChasePlayer()
    {
        float distanceToChase = Vector3.Distance(enemy.transform.position, target.position);

        if (distanceToChase <= 10f)
        {
            agent.SetDestination(target.position);
        }
    }

    void InAttackRange()
    {
        float distanceToAttack = Vector3.Distance(enemy.transform.position, target.position);

        if (distanceToAttack <= 3f)
        {
            canAttack = true;
            agent.isStopped = true;
            agent.speed = 0f;
        }
        else
        {
            canAttack = false;
            agent.isStopped = false;
            agent.speed = 1.5f;
        }
    }

    public override State RunCurrentState()
    {
        if (canAttack == true)
        {
            return attackState;
        }
        else
        {
            return this;
        }
    }
}
