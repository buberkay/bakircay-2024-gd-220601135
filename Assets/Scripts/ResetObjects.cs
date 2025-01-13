using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetObjects : MonoBehaviour
{
    public Button resetButton;
    private List<GameObject> gameObjects; 
    private List<Vector3> originalPositions;
    private List<Quaternion> originalRotations;

    void Start()
    {
        if (resetButton != null)
        {
            resetButton.onClick.AddListener(ResetAllObjects);
        }
        else
        {
            Debug.LogError("Reset button is not assigned.");
        }

        GameObject[] objectsInScene = GameObject.FindGameObjectsWithTag("GameObject");

        gameObjects = new List<GameObject>(objectsInScene);

        originalPositions = new List<Vector3>();
        originalRotations = new List<Quaternion>();

        foreach (GameObject obj in gameObjects)
        {
            originalPositions.Add(obj.transform.position);
            originalRotations.Add(obj.transform.rotation);
        }
    }

    void ResetAllObjects()
    {
        for (int i = 0; i < gameObjects.Count; i++)
        {
            if (gameObjects[i] != null)
            {
                gameObjects[i].transform.position = originalPositions[i];
                gameObjects[i].transform.rotation = originalRotations[i];
            }
        }
    }
}
