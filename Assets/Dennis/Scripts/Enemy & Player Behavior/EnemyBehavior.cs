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
    [SerializeField]
    private Animator deathAnimation;

    private void Awake()
    {
        currentEnemyHealth = maxEnemyHealth;
    }
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

        deathAnimation.SetBool("Death", true);

        yield return new WaitForSeconds(5);

        Destroy(gameObject);
    }
}
