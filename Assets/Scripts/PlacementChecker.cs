using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementChecker : MonoBehaviour
{
    private bool isOccupied = false; // Alanýn dolu olup olmadýðýný kontrol ediyoruz.

    private void OnTriggerEnter(Collider other)
    {
        // Eðer alan doluysa ve yeni bir nesne girmeye çalýþýyorsa, iþlemi durdur.
        if (isOccupied)
        {
            Debug.Log("Alan zaten dolu! Yeni nesne yerleþtirilemez.");
            return;
        }

        // Eðer giden nesne uygun Tag'e sahipse, iþlem yap.
        if (other.CompareTag("Draggable"))
        {
            Debug.Log("Nesne yerleþtirildi");
            isOccupied = true; // Alan artýk dolu.
            other.GetComponent<Controller>().enabled = false; // Nesnenin hareketini kapat.
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Alanýn boþaltýlmasý durumu.
        if (other.CompareTag("Draggable"))
        {
            Debug.Log("Nesne alandan çýkarýldý");
            isOccupied = false; // Alan tekrar kullanýlabilir.
        }
    }
}
