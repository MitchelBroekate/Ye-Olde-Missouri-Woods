using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public AttackState attackState;
    public bool canAttack;

    [Header("Enemy Type")]
    [SerializeField]
    private bool isMelee;
    [SerializeField]
    private bool isRanged;

    [Header("Attributes")]
    [SerializeField]
    private GameObject enemy;
    private Transform target;
    private float rotationSpeed = 1.5f;
    [SerializeField]
    private float movementSpeed;

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

        if (isMelee == true)
        {
            if (distanceToChase <= 10f)
            {
                enemy.transform.position = Vector3.MoveTowards(transform.position, target.transform.position, movementSpeed * Time.deltaTime);
                Vector3 dir = target.position - enemy.transform.position;
                Quaternion rotation = Quaternion.Slerp(enemy.transform.rotation, Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);
                rotation.x = 0;
                rotation.z = 0;
                enemy.transform.rotation = rotation;
                enemy.transform.position = Vector3.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
            }
        }

        if (isRanged == true)
        {
            if (distanceToChase <= 20f)
            {
                enemy.transform.position = Vector3.MoveTowards(transform.position, target.transform.position, movementSpeed * Time.deltaTime);
                Vector3 dir = target.position - enemy.transform.position;
                Quaternion rotation = Quaternion.Slerp(enemy.transform.rotation, Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);
                rotation.x = 0;
                rotation.z = 0;
                enemy.transform.rotation = rotation;
                enemy.transform.position = Vector3.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
            }
        }
    }

    void InAttackRange()
    {
        float distanceToAttack = Vector3.Distance(enemy.transform.position, target.position);

        if (isMelee == true)
        {
            if (distanceToAttack <= 3f)
            {
                canAttack = true;
                movementSpeed = 0;
            }
            else
            {
                canAttack = false;
                movementSpeed = 1.5f;
            }
        }

        if (isRanged == true)
        {
            if (distanceToAttack <= 10f)
            {
                canAttack = true;
                movementSpeed = 0;
            }
            else
            {
                canAttack = false;
                movementSpeed = 1.5f;
            }
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
