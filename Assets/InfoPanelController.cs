using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanelController : MonoBehaviour
{
    public GameObject panelPregunta;
    public GameObject panelInfo;

    public void VerMasInformacion()
    {
        panelPregunta.SetActive(false);
        panelInfo.SetActive(true);
    }

    public void VolverAtras()
    {
        panelInfo.SetActive(false);
        panelPregunta.SetActive(true);
    }
}