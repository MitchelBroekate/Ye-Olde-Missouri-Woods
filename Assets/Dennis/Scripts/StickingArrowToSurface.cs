using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickingArrowToSurface : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private SphereCollider myCollider;
    [SerializeField]
    private GameObject stickingArrow;

    public GameObject arrow;
    public int damage = 5;
    public float waitTime = 4f;


    private void OnCollisionEnter(Collision collision)
    {
        rb.isKinematic = true;
        myCollider.isTrigger = true;

        arrow = Instantiate(stickingArrow);
        arrow.transform.position = transform.position;
        arrow.transform.forward = transform.forward;

        if (collision.collider.attachedRigidbody != null)
        {
            arrow.transform.parent = collision.collider.attachedRigidbody.transform;
        }
        else
        {
            StartCoroutine("DestroyStickingArrow");
        }

        //Hier toevoegen wanneer de arrow damage moet doen.
        collision.collider.GetComponent<EnemyBehavior>().TakeDamage(damage);

        Destroy(gameObject);
    }

    IEnumerator DestroyStickingArrow()
    {
        yield return new WaitForSeconds(waitTime);

        Destroy(arrow);
    } 
}
