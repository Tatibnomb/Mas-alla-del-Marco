using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloquearRotacion : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Bloquear todas las rotaciones desde el Rigidbody
            rb.freezeRotation = true;
        }
    }

    void LateUpdate()
    {
        // Mantener siempre rotación con Y = 0
        transform.rotation = Quaternion.Euler(
            0f,
            0f,
            0f
        );
    }
}