using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelActivator : MonoBehaviour
{
    public GameObject panel;
    public Transform player;
    public float activationDistance = 2f;

    void Update()
    {
        if (!panel || !player) return;

        float distance = Vector3.Distance(player.position, transform.position);
        panel.SetActive(distance <= activationDistance);
    }
}