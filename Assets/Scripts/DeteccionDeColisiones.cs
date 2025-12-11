using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionDeColisiones : MonoBehaviour
{
    [Header("Panel general de la escena")]
    public GameObject panelMovible;

    [Header("Texto dentro del panel")]
    public TMPro.TextMeshProUGUI labelTexto;

    [Header("Punto donde aparecerá el panel junto al cuadro")]
    public Transform puntoPanel;

    [Header("El jugador debe tener el tag Player")]
    public string playerTag = "Player";

    // Info del cuadro
    private InfoDelCuadro info;

    private void Start()
    {
        if (panelMovible == null)
        {
            Debug.LogError("No asignaste el panelMovible en " + name);
            enabled = false;
            return;
        }

        if (labelTexto == null)
        {
            Debug.LogError("No asignaste labelTexto para el panel en " + name);
            enabled = false;
            return;
        }

        if (puntoPanel == null)
        {
            Debug.LogError("No asignaste puntoPanel en " + name);
            enabled = false;
            return;
        }

        info = GetComponent<InfoDelCuadro>();
        if (info == null)
        {
            Debug.LogError("Este cuadro no tiene InfoDelCuadro: " + name);
            enabled = false;
            return;
        }

        // Al inicio el panel está oculto
        panelMovible.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(playerTag)) return;

        panelMovible.SetActive(true);

        // Mover panel al punto del cuadro
        panelMovible.transform.position = puntoPanel.position;

        Transform player = other.transform;
        Vector3 direccion = ((player.position - panelMovible.transform.position).normalized);
        direccion.y = 0; // evitar rotación inclinada
        panelMovible.transform.rotation = Quaternion.LookRotation(direccion);
        Debug.Log("Panel orientado a: " + direccion);
        labelTexto.text = info.descripcionDelCuadro;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag(playerTag)) return;

        // Ocultar panel al alejarse
        panelMovible.SetActive(false);
    }

}