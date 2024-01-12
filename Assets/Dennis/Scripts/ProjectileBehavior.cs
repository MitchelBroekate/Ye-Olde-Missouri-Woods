using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    private Transform target;

    public float speed;

    public int enemyDamage;
    public int enemyRageValue;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        Damage(target);

        Destroy(gameObject);
    }

    void Damage (Transform target)
    {
        if (target != null)
        {
            target.GetComponent<PlayerScript>().PlayerTakeDamage(enemyDamage);

            target.GetComponent<PlayerScript>().PlayerGetRage(enemyRageValue);
        }
    }
}
