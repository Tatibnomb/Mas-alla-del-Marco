using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionDeColisiones : MonoBehaviour
{
    public GameObject mensajeUI;

    void Start()
    {
        if (mensajeUI != null)
            mensajeUI.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (mensajeUI != null)
                mensajeUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (mensajeUI != null)
                mensajeUI.SetActive(false);
        }
    }
}