using UnityEngine;
using TMPro; // Para usar TextMeshPro

public class InfoPanelController : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject infoPanel;
    public TMP_Text infoText;
    public Transform cuadro;
    public Transform player;
    public GameObject botonVerMas;
    public GameObject botonCerrar;

    [Header("Textos del cuadro")]
    [TextArea] public string textoPregunta = "¿Querés ver más información de la obra?";
    [TextArea] public string textoInfo = "Obra: La Noche Estrellada\nAutor: Vincent van Gogh\nPintada en 1889 durante su estancia en Saint-Rémy-de-Provence. Representa la vista nocturna desde su habitación en el asilo, combinando observación y emoción.";

    private bool panelActivo = false;

    void Start()
    {
        if (infoPanel != null)
            infoPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !panelActivo)
        {
            MostrarPregunta();
            panelActivo = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OcultarPanel();
            panelActivo = false;
        }
    }

    public void MostrarPregunta()
    {
        if (infoPanel == null || cuadro == null || player == null) return;

        // Activar panel y colocarlo a la derecha del cuadro
        infoPanel.SetActive(true);
        infoPanel.transform.position = cuadro.position + cuadro.right * 0.5f;

        // Hacer que el panel mire hacia el jugador
        Vector3 lookDirection = player.position - infoPanel.transform.position;
        lookDirection.y = 0;
        infoPanel.transform.rotation = Quaternion.LookRotation(lookDirection);

        // Mostrar la pregunta
        infoText.text = textoPregunta;

        // Mostrar el botón "Ver más", ocultar "Cerrar"
        if (botonVerMas != null) botonVerMas.SetActive(true);
        if (botonCerrar != null) botonCerrar.SetActive(false);
    }

    public void MostrarInformacion()
    {
        // Cambiar el texto a la información completa
        if (infoText != null)
            infoText.text = textoInfo;

        if (botonVerMas != null) botonVerMas.SetActive(false);
        if (botonCerrar != null) botonCerrar.SetActive(true);
    }

    public void OcultarPanel()
    {
        if (infoPanel != null)
            infoPanel.SetActive(false);
    }
}