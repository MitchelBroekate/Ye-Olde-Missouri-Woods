using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField]
    int maxEnemyHealth;
    public int currentEnemyHealth;
    bool isEnemyDead = false;

    //[Header("Enemy Movement/Attack")]
    //NavMeshAgent agent;
    //private Transform target;
    //float timeBetweenAttacks = 5f;
    //float timer;

    #region Awake/Start/Update
    //private void Awake()
    //{
    //    agent = GetComponent<NavMeshAgent>();
    //}

    //private void Start()
    //{
    //    currentEnemyHealth = maxEnemyHealth;
    //    target = GameObject.Find("OVRCameraRig").transform;
    //}

    //private void Update()
    //{
    //    timer -= Time.deltaTime;

    //    if (target)
    //    {
    //        agent.SetDestination(target.position);
    //        if (timer <= 0 && currentEnemyHealth > 0)
    //        {
    //            //StartCoroutine("Test");
    //            DealDamage();
    //        }
    //    }
    //}
    //#endregion

    //#region Deal/Take Damage
    //public void DealDamage()
    //{
    //    timer = timeBetweenAttacks;

    //    float minAttackDistance = 1.5f;

    //    float distance = Vector3.Distance(agent.transform.position, target.position);

    //    int currentPlayerHealth = target.GetComponent<PlayerScript>().currentPlayerHealth;

    //    if (distance < minAttackDistance)
    //    {
    //        target.GetComponent<PlayerScript>().PlayerTakeDamage(enemyDamage);
    //        agent.isStopped = true;
    //        agent.speed = 0;
    //    }
    //    else
    //    {
    //        agent.isStopped= false;
    //        agent.speed = 2;
    //    }

    //    if (currentPlayerHealth <= 0)
    //    {
    //        target = null;
    //    }
    //}

    //IEnumerator Test()
    //{
    //    while(Animation.isDone == false)
    //    {
    //        yield return null;
    //    }

    //    print("done");
    //}

    public void TakeDamage(int damage)
    {
        currentEnemyHealth = currentEnemyHealth - damage;

        if (currentEnemyHealth <= 0 && isEnemyDead == false)
        {
            StartCoroutine("KillEnemy");
        }
    }

    IEnumerator KillEnemy()
    {
        Debug.Log("Dead");
        isEnemyDead = true;

        yield return new WaitForSeconds(2);

        Destroy(gameObject);
    }
    #endregion
}
