using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementChecker : MonoBehaviour
{
    private bool isOccupied = false; // Alan�n dolu olup olmad���n� kontrol ediyoruz.

    private void OnTriggerEnter(Collider other)
    {
        // E�er alan doluysa ve yeni bir nesne girmeye �al���yorsa, i�lemi durdur.
        if (isOccupied)
        {
            Debug.Log("Alan zaten dolu! Yeni nesne yerle�tirilemez.");
            return;
        }

        // E�er giden nesne uygun Tag'e sahipse, i�lem yap.
        if (other.CompareTag("Draggable"))
        {
            Debug.Log("Nesne yerle�tirildi");
            isOccupied = true; // Alan art�k dolu.
            other.GetComponent<Controller>().enabled = false; // Nesnenin hareketini kapat.
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Alan�n bo�alt�lmas� durumu.
        if (other.CompareTag("Draggable"))
        {
            Debug.Log("Nesne alandan ��kar�ld�");
            isOccupied = false; // Alan tekrar kullan�labilir.
        }
    }
}
