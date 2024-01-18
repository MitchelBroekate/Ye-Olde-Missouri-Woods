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

    public int damage = 5;
    public float waitTime = 3f;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Arrow Stuck");
        rb.isKinematic = true;
        myCollider.isTrigger = true;

        GameObject arrow = Instantiate(stickingArrow);
        arrow.transform.position = transform.position;
        arrow.transform.forward = transform.forward;
        
        if (collision.collider.attachedRigidbody != null)
        {
            Debug.Log("Arrow Stuck Parent");
            
            arrow.transform.parent = collision.collider.attachedRigidbody.transform;

        }
        else
        {
            StartCoroutine("DestroyStickingArrow");
        }
        
        collision.collider.GetComponent<EnemyBehavior>()?.TakeDamage(damage);

        Destroy(gameObject);

    }

    IEnumerator DestroyStickingArrow()
    {
        yield return new WaitForSeconds(waitTime);

        Debug.Log("Arrow Destroyed");

        Destroy(stickingArrow);
    } 
}
