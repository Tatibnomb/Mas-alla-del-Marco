using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionDeColisiones : MonoBehaviour
{
    [Header("Panel que se mueve y debe volver a su lugar")]
    public GameObject panelInfo;

    [Header("Ocultar al salir")]
    public bool ocultarAlSalir = true;

    // Guardamos posición/rotación original del panel
    private Vector3 posicionInicial;
    private Quaternion rotacionInicial;

    private Rigidbody rb;

    void Start()
    {
        if (panelInfo == null)
        {
            Debug.LogError("❌ No asignaste el panelInfo en el inspector.");
            enabled = false;
            return;
        }

        // Guardar posición inicial
        posicionInicial = panelInfo.transform.position;
        rotacionInicial = panelInfo.transform.rotation;

        // Buscar rigidbody si tiene
        rb = panelInfo.GetComponent<Rigidbody>();

        // Ocultar al inicio
        panelInfo.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        // Mostrar panel
        panelInfo.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (ocultarAlSalir)
        {
            panelInfo.SetActive(false);
        }

        // Resetear posición, rotación y física
        ResetearPanel();
    }

    private void ResetearPanel()
    {
        // Si tiene rigidbody, detener movimiento
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;  // congelarlo un momento
        }

        // Volver a la posición original
        panelInfo.transform.position = posicionInicial;
        panelInfo.transform.rotation = rotacionInicial;

        // Volver a activar el Rigidbody si había uno
        if (rb != null)
        {
            rb.isKinematic = false;
        }
    }
}