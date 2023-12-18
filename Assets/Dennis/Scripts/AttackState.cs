using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public ChaseState chaseState;
    public bool playerOutOfRange;

    [Header("General Attributes")]
    [SerializeField]
    private GameObject enemy;
    Transform target;
    [SerializeField]
    private int enemyDamage;

    [Header("Animation Attributes")]
    [SerializeField]
    private Animator attackAnimation;
    [SerializeField]
    private float animationTime;
    private bool canAttack;

    private void Start()
    {
        target = GameObject.Find("OVRCameraRig").transform;
        canAttack = true;
    }

    private void Update()
    {
        if (canAttack == true)
        {
            AttackPlayer();
        }
    }

    void AttackPlayer()
    {
        float inAttackRange = Vector3.Distance(enemy.transform.position, target.position);

        if (inAttackRange <= 3f)
        {
            StartCoroutine("Attack");
        }
        else
        {
            playerOutOfRange = true;
        }
    }

    IEnumerator Attack()
    {
        canAttack = false;

        attackAnimation.SetTrigger("Attack");

        target.GetComponent<PlayerScript>().PlayerTakeDamage(enemyDamage);

        yield return new WaitForSeconds(animationTime);

        canAttack = true;

        attackAnimation.ResetTrigger("Attack");
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
