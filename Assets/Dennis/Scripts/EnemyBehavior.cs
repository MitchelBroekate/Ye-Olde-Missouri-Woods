using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField]
    int maxEnemyHealth;
    [SerializeField]
    int currentEnemyHealth;
    bool isEnemyDead = false;
    [SerializeField]
    int enemyDamage;

    [Header("Enemy Movement/Attack")]
    NavMeshAgent agent;
    private Rigidbody rb;
    private Transform target;
    [SerializeField]
    float timeBetweenAttacks = 5f;
    float timer;

    #region Awake/Start/Update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        currentEnemyHealth = maxEnemyHealth;
        target = GameObject.Find("OVRCameraRig").transform;
        Debug.Log(target.name);
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && currentEnemyHealth > 0)
        {
            //StartCoroutine("Test");
            DealDamage();
        }

        if (target)
        {
            agent.SetDestination(target.position);
        }
    }
    #endregion

    #region Deal/Take Damage
    public void DealDamage()
    {
        timer = timeBetweenAttacks;

        float minAttackDistance = 1f;

        float distance = Vector3.Distance(agent.transform.position, target.position);

        int currentPlayerHealth = target.GetComponent<PlayerScript>().currentPlayerHealth;

        if (distance < minAttackDistance)
        {
            target.GetComponent<PlayerScript>().PlayerTakeDamage(enemyDamage);
        }
    }

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
