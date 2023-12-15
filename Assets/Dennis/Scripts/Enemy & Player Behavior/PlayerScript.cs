using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField]
    private int maxPlayerHealth;
    public int currentPlayerHealth;
    private bool playerIsDead;

    private void Start()
    {
        currentPlayerHealth = maxPlayerHealth;
    }

    public void PlayerTakeDamage(int enemyDamage)
    {
        currentPlayerHealth = currentPlayerHealth - enemyDamage;

        Debug.Log("Player Took Damage");

        if (currentPlayerHealth <= 0 && playerIsDead == false)
        {
            Debug.Log("Player is Dead");
        }
    }
}
