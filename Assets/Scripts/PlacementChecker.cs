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
            Debug.Log("Nesne ba�ar�yla yerle�tirildi.");
            DisableDragging(placedObject);
        }
        else
        {
            Debug.Log("Yerle�tirme alan� dolu! Ba�ka bir nesne yerle�tirilemez.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (placedObject == other.gameObject)
        {
            placedObject = null;
            Debug.Log("Nesne alandan ��kar�ld�.");
        }
    }

    private void DisableDragging(GameObject obj)
    {
        obj.GetComponent<NewBehaviourScript>().enabled = false; 
    }
}
