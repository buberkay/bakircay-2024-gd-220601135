using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPositionAssigner : MonoBehaviour
{
    public GameObject[] objectsToReposition; // Yeniden konumlandýrýlacak objeler
    public Vector3 repositionAreaSize = new Vector3(10, 0, 10); // Yeniden konumlandýrýlacak alanýn boyutu

    void Start()
    {
        RepositionObjects();
    }

    void RepositionObjects()
    {
        foreach (var obj in objectsToReposition)
        {
            Vector3 randomPosition = GetRandomPosition();
            obj.transform.position = randomPosition;
        }
    }

    Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(-repositionAreaSize.x / 2, repositionAreaSize.x / 2);
        float randomY = Random.Range(-repositionAreaSize.y / 2, repositionAreaSize.y / 2);
        float randomZ = Random.Range(-repositionAreaSize.z / 2, repositionAreaSize.z / 2);
        return new Vector3(randomX, randomY, randomZ) + transform.position;
    }
}
