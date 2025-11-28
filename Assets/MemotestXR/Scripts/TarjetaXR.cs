using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class TarjetaXR : XRBaseInteractable
{
    [Header("UI Elements")]
    public Image imagenUI;
    public TextMeshProUGUI textoUI;

    [HideInInspector] public string id;

    private bool revelada = false;
    private MemotestXRManager manager;

    protected override void Awake()
    {
        base.Awake();
        manager = FindObjectOfType<MemotestXRManager>();
    }

    public void Configurar(Sprite imagen, string texto, string id)
    {
        this.id = id;

        if (imagen != null)
        {
            imagenUI.sprite = imagen;
            imagenUI.gameObject.SetActive(false);
            textoUI.gameObject.SetActive(false);
        }
        else
        {
            imagenUI.gameObject.SetActive(false);
            textoUI.text = texto;
            textoUI.gameObject.SetActive(false);
        }
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        manager.Seleccionar(this);
    }

    public void Revelar(bool esImagen)
    {
        if (esImagen)
        {
            imagenUI.gameObject.SetActive(true);
        }
        else
        {
            textoUI.gameObject.SetActive(true);
        }
        revelada = true;
    }

    public void Ocultar()
    {
        imagenUI.gameObject.SetActive(false);
        textoUI.gameObject.SetActive(false);
        revelada = false;
    }

    public void Desactivar()
    {
        enabled = false;
        GetComponent<Collider>().enabled = false;
    }
}