using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionDeColisiones : MonoBehaviour
{
    [Header("Panel que se puede agarrar (Panel 1)")]
    public GameObject panelMovible;

    [Header("El jugador debe tener tag Player")]
    public string playerTag = "Player";

    // Guardar posición original
    private Vector3 posicionInicial;
    private Quaternion rotacionInicial;

    private Rigidbody rb;

    void Start()
    {
        if (panelMovible == null)
        {
            Debug.LogError("No asignaste el panelMovible.");
            enabled = false;
            return;
        }

        // Guardar posición y rotación inicial
        posicionInicial = panelMovible.transform.position;

        // Mantener Y = 0
        rotacionInicial = Quaternion.Euler(
            panelMovible.transform.rotation.eulerAngles.x,
            0f,
            panelMovible.transform.rotation.eulerAngles.z
        );

        rb = panelMovible.GetComponent<Rigidbody>();

        // Ocultarlo al inicio
        panelMovible.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(playerTag)) return;

        // Mostrar panel que se agarra
        panelMovible.SetActive(true);

        // Asegurar rotación correcta
        panelMovible.transform.rotation = rotacionInicial;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag(playerTag)) return;

        // Resetear su posición primero
        ResetearPanel();

        // Ahora sí ocultarlo
        panelMovible.SetActive(false);
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
        panelMovible.transform.position = posicionInicial;

        // Rotación con Y = 0
        panelMovible.transform.rotation = rotacionInicial;

        if (rb != null)
        {
            // Reactivar física
            rb.isKinematic = false;
        }
    }
}