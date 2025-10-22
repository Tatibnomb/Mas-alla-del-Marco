using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionDeColisiones : MonoBehaviour
{
    public GameObject hintPanel;

    void Start()
    {
        if (hintPanel != null)
            hintPanel.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && hintPanel != null)
            hintPanel.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && hintPanel != null)
            hintPanel.SetActive(false);
    }
}