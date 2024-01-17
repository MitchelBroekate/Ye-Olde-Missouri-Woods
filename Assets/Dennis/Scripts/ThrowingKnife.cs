using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingKnife : MonoBehaviour
{
    List<Vector3> trackingPos = new List<Vector3>();
    public float velocity = 1000f;

    bool pickedUp;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pickedUp == true)
        {
            rb.useGravity = false;

            if (trackingPos.Count > 15)
            {
                trackingPos.RemoveAt(0);
            }
            trackingPos.Add(transform.position);
        }
    }

    public void ThrowingPickUp()
    {
        pickedUp = true;
    }

    public void ThrowingLetGo()
    {
        pickedUp = false;
        Vector3 direction = trackingPos[trackingPos.Count - 1] - trackingPos[0];
        rb.AddForce(direction * velocity);
        rb.useGravity = true;
        GetComponent<Collider>().isTrigger = false;
    }
}
