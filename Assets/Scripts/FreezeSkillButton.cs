using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreezeSkillButton : MonoBehaviour
{
    public Color freezeColor = Color.blue;
    public Button freezeButton;
    private bool isFrozen = false;

    void Start()
    {
        if (freezeButton != null)
        {
            freezeButton.onClick.AddListener(ActivateFreezeSkill);
        }
        else
        {
            Debug.LogError("Freeze button is not assigned.");
        }
    }

    void ActivateFreezeSkill()
    {
        if (!isFrozen)
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag("GameObject");

            foreach (var obj in objects)
            {
                Renderer rend = obj.GetComponent<Renderer>();

                if (rend != null)
                {
                    rend.material.color = freezeColor;
                }

                Rigidbody rb = obj.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = true;
                }
            }

            StartCoroutine(FreezeDuration());

            isFrozen = true;
        }
    }

    IEnumerator FreezeDuration()
    {
        yield return new WaitForSeconds(5);

        GameObject[] objects = GameObject.FindGameObjectsWithTag("GameObject");

        foreach (var obj in objects)
        {
            Renderer rend = obj.GetComponent<Renderer>();

            if (rend != null)
            {
                rend.material.color = Color.white; 
            }

            Rigidbody rb = obj.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
            }
        }

        isFrozen = false;
    }

}
