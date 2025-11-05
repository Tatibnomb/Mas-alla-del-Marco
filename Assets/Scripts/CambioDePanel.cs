using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioDePanel : MonoBehaviour
{
    public GameObject panelPregunta;
    public GameObject panelInfo;

    void Start()
    {
        // Al inicio, solo mostramos la pregunta
        if (panelPregunta != null) panelPregunta.SetActive(true);
        if (panelInfo != null) panelInfo.SetActive(false);
    }

    public void MostrarInfo()
    {
        // Cuando el usuario presione el botón, cambiamos los paneles
        if (panelPregunta != null) panelPregunta.SetActive(false);
        if (panelInfo != null) panelInfo.SetActive(true);
    }
}