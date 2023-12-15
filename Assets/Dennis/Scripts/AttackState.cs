using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackState : State
{
    public ChaseState chaseState;
    public bool playerOutOfRange;

    [Header("Attributes")]
    [SerializeField]
    private GameObject enemy;
    Transform target;
    public float timeBetweenAttacks = 5f;
    public float timer;
    [SerializeField]
    private int enemyDamage;

    private void Start()
    {
        target = GameObject.Find("OVRCameraRig").transform;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        int currentEnemyHealth = enemy.GetComponent<EnemyBehavior>().currentEnemyHealth;

        //Dit gedeelte voert hij niet uit.
        if (timer <= 0 && currentEnemyHealth > 0)
        {
            AttackPlayer();
        }
    }

    void AttackPlayer()
    {
        timer = timeBetweenAttacks;

        float inAttackRange = Vector3.Distance(enemy.transform.position, target.position);

        Debug.Log(inAttackRange);

        if (inAttackRange <= 3f)
        {
            Debug.Log("Attacked Player");
            target.GetComponent<PlayerScript>().PlayerTakeDamage(enemyDamage);
        }
        else
        {
            playerOutOfRange = true;
        }
    }

    public override State RunCurrentState()
    {
        if (playerOutOfRange == true)
        {
            return chaseState;
        }
        else
        {
            return this;
        }
    }
}
