using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpSkillButton : MonoBehaviour
{
    public float jumpForce = 300f;
    public Button jumpButton;

    void Start()
    {
        if (jumpButton != null)
        {
            jumpButton.onClick.AddListener(ActivateJumpSkill);
        }
        else
        {
            Debug.LogError("Jump button is not assigned.");
        }
    }

    void ActivateJumpSkill()
    {
        Debug.Log("Jump button clicked!");
        GameObject[] objects = GameObject.FindGameObjectsWithTag("GameObject");

        foreach (var obj in objects)
        {
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(Vector3.up * jumpForce);
            }
        }
    }
}
