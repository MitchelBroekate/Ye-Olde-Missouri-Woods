using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSfx : MonoBehaviour
{
    public AudioSource clip;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            clip.Play();
        }
    }
}
