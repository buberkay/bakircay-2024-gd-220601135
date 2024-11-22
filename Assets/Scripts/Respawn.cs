using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Vector3 respawnPosition = Vector3.zero;

    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.y < 0f)
        {
            RespawnObject();
        }
    }

    void RespawnObject()
    {
        transform.position = respawnPosition;
        Debug.Log($"{gameObject.name} respawned to {respawnPosition}");
    }
}
