using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public ChaseState chaseState;
    public bool playerOutOfRange;

    [Header("Enemy Type")]
    [SerializeField]
    private bool isMelee;
    [SerializeField]
    private bool isRanged;

    [Header("General Attributes")]
    [SerializeField]
    private GameObject enemy;
    Transform target;
    public int enemyDamage;
    public int enemyRageValue;

    [Header("Ranged Enemy Attributes")]
    [SerializeField]
    private Transform firePoint;
    public float fireRate;
    public float fireCountdown = 0f;
    public GameObject bulletPrefab;


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

        bool isDead = enemy.GetComponent<EnemyBehavior>().isEnemyDead;

        if (isDead == false)
        {
            if (canAttack == true)
            {
                AttackPlayer();
            }

            fireCountdown -= Time.deltaTime;
        }
    }

    void AttackPlayer()
    {
        float inAttackRange = Vector3.Distance(enemy.transform.position, target.position);

        if (isMelee == true)
        {
            if (inAttackRange <= 3f)
            {
                StartCoroutine("Attack");
            }
            else
            {
                playerOutOfRange = true;
            }
        }

        if (isRanged == true)
        {
            if (inAttackRange <= 10f)
            {
                if (fireCountdown <= 0f)
                {
                    StartCoroutine("RangedAttack");
                    fireCountdown = 1f / fireRate;
                }
            }
            else
            {
                playerOutOfRange = true;
            }
        }
    }

    IEnumerator Attack()
    {
        canAttack = false;

        attackAnimation.SetTrigger("Attack");

        target.GetComponent<PlayerScript>().PlayerTakeDamage(enemyDamage);

        target.GetComponent<PlayerScript>().PlayerGetRage(enemyRageValue);

        yield return new WaitForSeconds(animationTime);

        canAttack = true;

        attackAnimation.ResetTrigger("Attack");
    }

    IEnumerator RangedAttack()
    {
        GameObject projectileGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        ProjectileBehavior projectile = projectileGO.GetComponent<ProjectileBehavior>();

        if (projectile != null)
        {
            projectile.Seek(target);
        }

        canAttack = false;

        attackAnimation.SetTrigger("Attack");

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
