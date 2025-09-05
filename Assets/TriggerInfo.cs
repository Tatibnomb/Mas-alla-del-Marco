using UnityEngine;
using UnityEngine.XR;

public class TriggerInfo : MonoBehaviour
{
    public GameObject hintPanel;
    public GameObject infoPanel;
    private bool isPlayerInside = false;

    void Start()
    {
        hintPanel.SetActive(false);
        infoPanel.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            hintPanel.SetActive(true);
            isPlayerInside = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            hintPanel.SetActive(false);
            infoPanel.SetActive(false);
            isPlayerInside = false;
        }
    }

    void Update()
    {
        if (isPlayerInside)
        {
            // Buscar el control derecho
            InputDevice rightHand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

            bool buttonA;
            if (rightHand.TryGetFeatureValue(CommonUsages.primaryButton, out buttonA) && buttonA)
            {
                infoPanel.SetActive(true);
            }
        }
    }
}