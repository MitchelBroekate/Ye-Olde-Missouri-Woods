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
    [SerializeField]
    private float meleeSpeed;
    [SerializeField]
    private float rangedSpeed;


    [Header("Attributes")]
    [SerializeField]
    private GameObject enemy;
    private Transform target;
    private float rotationSpeed = 1.5f;

    private void Start()
    {
        target = GameObject.Find("OVRCameraRig").transform;
    }

    private void Update()
    {
        bool isDead = enemy.GetComponent<EnemyBehavior>().isEnemyDead;

        if (isDead == false)
        {
            ChasePlayer();
            InAttackRange();
        }
    }

    void ChasePlayer()
    {
        float distanceToChase = Vector3.Distance(enemy.transform.position, target.position);

        if (isMelee == true)
        {
            if (distanceToChase <= 10f)
            {
                enemy.transform.position = Vector3.MoveTowards(transform.position, target.transform.position, meleeSpeed * Time.deltaTime);
                Vector3 dir = target.position - enemy.transform.position;
                Quaternion rotation = Quaternion.Slerp(enemy.transform.rotation, Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);
                enemy.transform.rotation = rotation;
            }
        }

        if (isRanged == true)
        {
            if (distanceToChase <= 10f)
            {
                enemy.transform.position = Vector3.MoveTowards(transform.position, target.transform.position, rangedSpeed * Time.deltaTime);
                Vector3 dir = target.position - enemy.transform.position;
                Quaternion rotation = Quaternion.Slerp(enemy.transform.rotation, Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);
                enemy.transform.rotation = rotation;
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
                meleeSpeed = 0;
            }
            else
            {
                canAttack = false;
                meleeSpeed = 1.5f;
            }
        }

        if (isRanged == true)
        {
            if (distanceToAttack <= 7.5f)
            {
                canAttack = true;
                rangedSpeed = 0;
            }
            else
            {
                canAttack = false;
                rangedSpeed = 0.75f;
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
