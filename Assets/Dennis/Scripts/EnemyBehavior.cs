using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public int currentHealth = 20;
    public static bool isEnemyDead = false;

    public void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;

        if (currentHealth <= 0 && isEnemyDead == false)
        {
            Debug.Log("Dead");
            gameObject.GetComponent<Renderer>().material.SetColor("Dead", Color.gray);
            isEnemyDead = true;
        }
    }

    IEnumerator KillEnemy()
    {
        Debug.Log("Dead");
        isEnemyDead = true;

        yield return new WaitForSeconds(3);

        Destroy(gameObject);
    }
}
