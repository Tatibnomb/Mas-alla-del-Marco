using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

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
    [TextArea] public string textoInfo = "Obra: La Noche Estrellada\nAutor: Vincent van Gogh...";

    private bool panelActivo = false;

    void Start()
    {
        if (infoPanel != null)
            infoPanel.SetActive(false);

        var interactable = GetComponent<XRBaseInteractable>();
        if (interactable != null)
            interactable.selectEntered.AddListener(_ => MostrarInformacion());
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

        infoPanel.SetActive(true);
        infoPanel.transform.position = cuadro.position + cuadro.forward * 0.5f;

        Vector3 lookDirection = player.position - infoPanel.transform.position;
        lookDirection.y = 0;
        infoPanel.transform.rotation = Quaternion.LookRotation(lookDirection);

        infoText.text = textoPregunta;
        if (botonVerMas != null) botonVerMas.SetActive(true);
        if (botonCerrar != null) botonCerrar.SetActive(false);
    }

    public void MostrarInformacion()
    {
        if (!infoPanel.activeSelf) return;

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