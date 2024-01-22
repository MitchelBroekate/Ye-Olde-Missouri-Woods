using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSFX : MonoBehaviour
{
    public AudioSource clip;
    public Rigidbody rb;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            clip.Play();
            rb.isKinematic = true;
        }
    }
}
