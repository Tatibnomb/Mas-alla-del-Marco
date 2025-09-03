using UnityEngine;
using UnityEngine.XR;
using TMPro; // necesario para TextMeshPro

public class InfoObraInteractiva : MonoBehaviour
{
    [Header("Asignaciones en el Inspector")]
    public GameObject hintPanel;        // Panel con el mensaje
    public TextMeshProUGUI hintText;    // El componente TMP dentro del hintPanel
    public GameObject infoPanel;        // Panel con la info detallada
    public Transform player;            // La cámara XR Rig
    public string nombreObra = "La Última Cena";

    [Header("Parámetros de Interacción")]
    public float distanciaActivacion = 2.0f; // metros

    private bool enRango = false;

    void Start()
    {
        // Inicializamos
        if (hintPanel != null) hintPanel.SetActive(false);
        if (infoPanel != null) infoPanel.SetActive(false);

        // Armamos el texto automáticamente
        if (hintText != null)
        {
            hintText.text = "Presiona el botón de Meta para más información de " + nombreObra;
        }
    }

    void Update()
    {
        if (player == null) return;

        float dist = Vector3.Distance(player.position, transform.position);

        if (dist < distanciaActivacion)
        {
            enRango = true;
            if (hintPanel != null) hintPanel.SetActive(true);

            // Que el hint siempre mire al jugador
            if (hintPanel != null)
            {
                hintPanel.transform.LookAt(player);
                hintPanel.transform.Rotate(0, 180, 0);
            }
        }
        else
        {
            enRango = false;
            if (hintPanel != null) hintPanel.SetActive(false);
            if (infoPanel != null) infoPanel.SetActive(false);
        }

        // Si el jugador está en rango y presiona botón → mostrar info
        if (enRango && GetMetaButtonPressed())
        {
            if (infoPanel != null)
            {
                infoPanel.SetActive(true);
                infoPanel.transform.LookAt(player);
                infoPanel.transform.Rotate(0, 180, 0);
            }
        }
    }

    bool GetMetaButtonPressed()
    {
        // Ejemplo: botón A del mando derecho
        InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        bool pressed = false;

        if (device.TryGetFeatureValue(CommonUsages.primaryButton, out pressed) && pressed)
        {
            return true;
        }

        return false;
    }
}