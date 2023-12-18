using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField]
    private int maxPlayerHealth;
    public int currentPlayerHealth;

    private void Start()
    {
        currentPlayerHealth = maxPlayerHealth;
    }

    public void PlayerTakeDamage(int enemyDamage)
    {
        currentPlayerHealth = currentPlayerHealth - enemyDamage;

        Debug.Log(currentPlayerHealth);

        if (currentPlayerHealth <= 0)
        {
            Debug.Log("Player is Dead");
        }
    }
}
