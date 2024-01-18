using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBehavior : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private MeshCollider myCollider;
    [SerializeField]
    private GameObject stickingKnife;

    public int knifeDamage;

    private void OnCollisionEnter(Collision collision)
    {
        rb.isKinematic = true;
        myCollider.isTrigger = true;

        GameObject knife = Instantiate(stickingKnife);
        knife.transform.position = transform.position;
        knife.transform.transform.forward = transform.forward;

        if (collision.collider.attachedRigidbody != null)
        {
            knife.transform.parent = collision.collider.attachedRigidbody.transform;
        }

        collision.collider.GetComponent<EnemyBehavior>()?.TakeDamage(knifeDamage);
    }
}
