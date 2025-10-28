using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionDeColisiones : MonoBehaviour
{
    [Header("Panel principal (Spatial Panel Manipulator Model)")]
    public GameObject spatialPanel;

    void Start()
    {
        // Asegurarse de que el panel empiece oculto
        if (spatialPanel != null)
            spatialPanel.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        // Si el jugador entra en el área, mostrar el panel
        if (other.CompareTag("Player") && spatialPanel != null)
        {
            Debug.Log("Jugador detectado: activando Spatial Panel Manipulator Model");
            spatialPanel.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Si el jugador sale del área, ocultar el panel
        if (other.CompareTag("Player") && spatialPanel != null)
        {
            Debug.Log("Jugador salió del área: desactivando Spatial Panel Manipulator Model");
            spatialPanel.SetActive(false);
        }
    }
}