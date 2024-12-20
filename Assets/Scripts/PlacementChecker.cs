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
            Debug.Log("Nesne başarıyla yerleştirildi.");
            DisableDragging(placedObject);
        }
        else
        {
            Debug.Log("Yerleştirme alanı dolu! Başka bir nesne yerleştirilemez.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (placedObject == other.gameObject)
        {
            placedObject = null;
            Debug.Log("Nesne alandan çıkarıldı.");
        }
    }

    private void DisableDragging(GameObject obj)
    {
        obj.GetComponent<NewBehaviourScript>().enabled = false; 
    }
}
