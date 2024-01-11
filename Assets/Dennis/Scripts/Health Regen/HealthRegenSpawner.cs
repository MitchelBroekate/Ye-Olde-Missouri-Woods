using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class HealthRegenSpawner : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField]
    private GameObject applePrefab;
    Transform target;
    [SerializeField]
    private GameObject spawnPoint;
    [SerializeField]
    private float cooldown;
    private bool canSpawn;


    private void Awake()
    {
        target = GameObject.Find("OVRCameraRig").transform;
    }

    void Update()
    {
        StartCoroutine(SpawnHealthRegen());
    }

    IEnumerator SpawnHealthRegen()
    {
        float distanceToPlayer = Vector3.Distance(gameObject.transform.position, target.position);

        Debug.Log(distanceToPlayer);

        if (distanceToPlayer < 5f)
        {
            if (Random.value > 0.2f)
            {
                if (!canSpawn)
                {
                    GameObject myApplePrefab = Instantiate(applePrefab, spawnPoint.transform.position, Quaternion.identity);
                    canSpawn = true;

                    myApplePrefab.transform.SetParent(spawnPoint.transform);

                    myApplePrefab.name = "AppleGrab";

                    yield return new WaitForSeconds(cooldown);

                    canSpawn = false;

                }
            }
        }
    }
}
