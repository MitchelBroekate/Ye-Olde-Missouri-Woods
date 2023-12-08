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
        Debug.Log("Arrow Stuck");
        rb.isKinematic = true;
        myCollider.isTrigger = true;

        arrow = Instantiate(stickingArrow);
        arrow.transform.position = transform.position;
        arrow.transform.forward = transform.forward;

        if (collision.collider.attachedRigidbody != null)
        {
            Debug.Log("Arrow Stuck Parent");
            Destroy(gameObject);
            arrow.transform.parent = collision.collider.attachedRigidbody.transform;
            collision.collider.GetComponent<EnemyBehavior>().TakeDamage(damage);
        }
        else
        {
            StartCoroutine("DestroyStickingArrow");
        }


    }

    IEnumerator DestroyStickingArrow()
    {
        yield return new WaitForSeconds(waitTime);

        Debug.Log("Arrow Destroyed");

        Destroy(gameObject);

        Destroy(arrow);
    } 
}
