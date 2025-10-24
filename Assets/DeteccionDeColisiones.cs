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
        {
            Debug.Log("Jugador detectado: activando panel");
            hintPanel.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && hintPanel != null)
        {
            Debug.Log("Jugador salió del área: desactivando panel");
            hintPanel.SetActive(false);
        }
    }
}
