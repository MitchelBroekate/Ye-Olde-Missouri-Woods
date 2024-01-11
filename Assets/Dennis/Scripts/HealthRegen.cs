using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRegen : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField]
    private PlayerScript playerScript;
    [SerializeField]
    private int healAmount;

    private void Awake()
    {
        //How to change name in Hierarchy
        //thisGameObject.name = "SaladBar";
        playerScript = FindObjectOfType<PlayerScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject appleGrab = GameObject.Find("AppleGrab");

        if (playerScript.currentPlayerHealth < playerScript.maxPlayerHealth)
        {
            if (other.gameObject.tag == "Apple")
            {
                playerScript.currentPlayerHealth += healAmount;
                Destroy(appleGrab);
            }
        }
    }
}
