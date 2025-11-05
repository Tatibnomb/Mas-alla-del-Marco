using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionDeColisiones : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject coachingCardRoot;
    public Transform playerCamera;

    [Header("Configuración")]
    public float distanceFromPainting = 0.6f; // distancia lateral del cuadro
    public float heightOffset = 0.5f;
    public bool ocultarAlSalir = true;

    private bool panelActivo = false;

    private void Start()
    {
        if (coachingCardRoot != null)
            coachingCardRoot.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !panelActivo)
        {
            Debug.Log("Jugador detectado: mostrando panel");

            coachingCardRoot.SetActive(true);
            panelActivo = true;

            if (playerCamera != null)
            {
                // Poner el panel a la derecha del cuadro
                Vector3 offset = transform.right * 0.5f;
                Vector3 position = transform.position + offset;
                position.y += heightOffset;

                coachingCardRoot.transform.position = position;

                // Hacer que el panel mire hacia el jugador
                Vector3 lookDirection = coachingCardRoot.transform.position - playerCamera.position;
                coachingCardRoot.transform.rotation = Quaternion.LookRotation(lookDirection);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && ocultarAlSalir)
        {
            Debug.Log("Jugador salió del área: ocultando panel");
            coachingCardRoot.SetActive(false);
            panelActivo = false;
        }
    }
}
