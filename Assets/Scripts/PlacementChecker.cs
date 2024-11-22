using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementChecker : MonoBehaviour
{
    private GameObject placedObject = null; 

    private void OnTriggerEnter(Collider other)
    {
        if (placedObject == null)
        {
            placedObject = other.gameObject; 
            Debug.Log("Nesne baþarýyla yerleþtirildi.");
            DisableDragging(placedObject);
        }
        else
        {
            Debug.Log("Yerleþtirme alaný dolu! Baþka bir nesne yerleþtirilemez.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (placedObject == other.gameObject)
        {
            placedObject = null;
            Debug.Log("Nesne alandan çýkarýldý.");
        }
    }

    private void DisableDragging(GameObject obj)
    {
        obj.GetComponent<NewBehaviourScript>().enabled = false; 
    }
}
