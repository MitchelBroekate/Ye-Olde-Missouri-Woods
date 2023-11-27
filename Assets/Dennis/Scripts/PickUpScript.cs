using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    [SerializeField]
    private GameObject bowString;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bow")
        {
            bowString.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Bow")
        {
            bowString.SetActive(false);
        }
    }
}
