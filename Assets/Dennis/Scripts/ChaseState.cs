using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : State
{
    [Header("Attributes")]
    [SerializeField]
    private GameObject enemy;
    NavMeshAgent agent;
    Rigidbody rb;
    Transform target;

    public AttackState attackState;
    public bool canAttack;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
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

        if (distanceToChase < 10f)
        {
            agent.SetDestination(target.position);
        }
    }

    void InAttackRange()
    {
        float distanceToAttack = Vector3.Distance(enemy.transform.position, target.position);

        Debug.Log(distanceToAttack);

        if (distanceToAttack < 3f)
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
