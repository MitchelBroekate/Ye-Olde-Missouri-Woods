using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject spawnPoint;
    [SerializeField]
    private int enemyLimit;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Trigger");

            StartCoroutine("SpawnEnemy");
        }
    }

    IEnumerator SpawnEnemy()
    {
        for (int i =0; i < enemyLimit;  i++)
        {
            enemyPrefab = Instantiate(enemyPrefab, spawnPoint.transform);

            enemyPrefab.transform.SetParent(spawnPoint.transform);

            yield return null;
        }
    }
}
