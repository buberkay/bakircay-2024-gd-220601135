using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Vector3 respawnPosition = Vector3.zero;

    // X ve Z eksenleri için sýnýrlar
    public float xMin = -4f;
    public float xMax = 4f;
    public float zMin = -5f;
    public float zMax = 5f;

    void Start()
    {
        ClampPosition();
    }

    void Update()
    {
        if (transform.position.y < 0f)
        {
            RespawnObject();
        }

        ClampPosition();
    }

    void ClampPosition()
    {
        Vector3 position = transform.position;

        position.x = Mathf.Clamp(position.x, xMin, xMax);
        position.z = Mathf.Clamp(position.z, zMin, zMax);

        position.y = Mathf.Clamp(position.y, -Mathf.Infinity, Mathf.Infinity);

        transform.position = position;
    }

    void RespawnObject()
    {
        transform.position = respawnPosition;
        Debug.Log($"{gameObject.name} respawned to {respawnPosition}");
    }
}
