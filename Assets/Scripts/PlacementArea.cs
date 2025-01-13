using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementArea : MonoBehaviour
{
    private GameObject placedObject;

    private void OnTriggerEnter(Collider other)
    {
        if (placedObject == null)
        {
            placedObject = other.gameObject;
            placedObject.GetComponent<Rigidbody>().isKinematic = true;
            placedObject.transform.position = transform.position;
            placedObject.GetComponent<Collider>().enabled = false;
        }
        else
        {
            if (placedObject.name != other.gameObject.name)
            {
                Rigidbody rb = other.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    Vector3 forceDirection = (other.transform.position - transform.position).normalized;
                    rb.AddForce(forceDirection * 500f);
                }
            }
            else
            {
                Destroy(placedObject);
                Destroy(other.gameObject);
                placedObject = null;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (placedObject != null && placedObject == other.gameObject)
        {
            placedObject.GetComponent<Collider>().enabled = true;
            placedObject = null;
        }
    }
}
