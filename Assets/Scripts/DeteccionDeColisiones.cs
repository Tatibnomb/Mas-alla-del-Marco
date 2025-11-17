using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionDeColisiones : MonoBehaviour
{
    [Header("Panel (Spatial Panel Scroll)")]
    public GameObject panelInfo;

    [Header("El jugador debe tener tag Player")]
    public string playerTag = "Player";

    // Guardar posición original
    private Vector3 posicionInicial;
    private Quaternion rotacionInicial;

    private Rigidbody rb;

    void Start()
    {
        if (panelInfo == null)
        {
            Debug.LogError("No asignaste el panelInfo.");
            enabled = false;
            return;
        }

        // Guardar posición y rotación inicial (pero luego forzaremos Y = 0)
        posicionInicial = panelInfo.transform.position;

        // Rotación inicial con Y = 0 SIEMPRE
        rotacionInicial = Quaternion.Euler(
            panelInfo.transform.rotation.eulerAngles.x,
            0f,
            panelInfo.transform.rotation.eulerAngles.z
        );

        rb = panelInfo.GetComponent<Rigidbody>();

        // Ocultar todo al inicio
        panelInfo.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(playerTag)) return;

        // Mostrar panel
        panelInfo.SetActive(true);

        // Restaurar rotación Y = 0 si fue arrastrado antes
        panelInfo.transform.rotation = rotacionInicial;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag(playerTag)) return;

        // Ocultar panel completamente
        panelInfo.SetActive(false);

        // Resetear posición y rotación
        ResetearPanel();
    }

    private void ResetearPanel()
    {
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            // Congelar mientras lo recolocamos
            rb.isKinematic = true;
        }

        // Volver a su lugar original
        panelInfo.transform.position = posicionInicial;

        // Volver con Y = 0 SIEMPRE
        panelInfo.transform.rotation = rotacionInicial;

        if (rb != null)
        {
            // Reactivar física
            rb.isKinematic = false;
        }
    }
}