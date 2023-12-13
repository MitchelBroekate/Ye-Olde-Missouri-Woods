using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField]
    private int currentEnemyHealth;
    bool isEnemyDead = false;
    [SerializeField]
    private int enemyDamage;

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
}
