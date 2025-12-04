using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VolverAPosicionFija : MonoBehaviour
{
    [Header("Posición fija a la cual volver")]
    public Transform posicionFija;

    private XRGrabInteractable grab;
    private Rigidbody rb;

    void Start()
    {
        if (posicionFija == null)
        {
            Debug.LogError("No asignaste la posición fija para que el panel vuelva.");
            enabled = false;
            return;
        }

        grab = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();

        if (grab == null)
        {
            Debug.LogError("No encontré XRGrabInteractable en este objeto.");
            enabled = false;
            return;
        }

        if (rb == null)
        {
            Debug.LogError("No encontré Rigidbody en este objeto.");
            enabled = false;
            return;
        }

        grab.selectExited.AddListener(OnSoltado);
    }

    private void OnDestroy()
    {
        if (grab != null)
        {
            grab.selectExited.RemoveListener(OnSoltado);
        }
    }

    private void OnSoltado(SelectExitEventArgs args)
    {
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        transform.position = posicionFija.position;

        transform.rotation = Quaternion.Euler(
            posicionFija.rotation.eulerAngles.x,
            0f,
            posicionFija.rotation.eulerAngles.z
        );

        rb.isKinematic = false;
    }
}