using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionDeColisiones : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject coachingCardRoot;
    public Transform playerCamera;

    [Header("Configuración")]
    public float distanceFromCamera = 3f;
    public float heightOffset = 0.5f;
    public bool ocultarAlSalir = false;

    private bool panelActivo = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !panelActivo)
        {
            Debug.Log("Jugador detectado: mostrando panel");

            coachingCardRoot.SetActive(true);
            panelActivo = true;

            if (playerCamera != null)
            {
                Vector3 forward = playerCamera.forward;
                forward.y = 0;

                Vector3 position = playerCamera.position + forward.normalized * distanceFromCamera;
                position.y += heightOffset;

                coachingCardRoot.transform.position = position;
                coachingCardRoot.transform.rotation = Quaternion.LookRotation(forward);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && ocultarAlSalir)
        {
            Debug.Log("Jugador salió del área: ocultando panel");
            // coachingCardRoot.SetActive(false);
            panelActivo = false;
        }
    }
}