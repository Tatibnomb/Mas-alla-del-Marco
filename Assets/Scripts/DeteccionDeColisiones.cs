using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionDeColisiones : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject panelInfo;
    public Transform playerCamera;

    [Header("Configuración")]
    public bool ocultarAlSalir = true;

    private bool panelActivo = false;

    private void Start()
    {
        if (panelInfo != null)
            panelInfo.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !panelActivo)
        {
            Debug.Log("Jugador detectado: mostrando panel");

            panelInfo.SetActive(true);
            panelActivo = true;

            if (playerCamera != null)
            {
                Vector3 lookDirection = playerCamera.position - panelInfo.transform.position;
                panelInfo.transform.rotation = Quaternion.LookRotation(lookDirection);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && ocultarAlSalir)
        {
            Debug.Log("Jugador salió del área: ocultando panel");
            panelInfo.SetActive(false);
            panelActivo = false;
        }
    }
}