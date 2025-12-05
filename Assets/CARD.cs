using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CARD : MonoBehaviour
{
    public int cardID;

    [Header("Materiales")]
    public Material materialFrente;
    public Material materialDorso;

    private MeshRenderer rend;
    private bool cartaMostrada = false;

    private XRSimpleInteractable interactable;

    private void Awake()
    {
        rend = GetComponentInChildren<MeshRenderer>();
        interactable = GetComponent<XRSimpleInteractable>();
    }

    private void Start()
    {
        rend.sharedMaterial = materialDorso;
        interactable.selectEntered.AddListener(OnCardSelected);
    }

    private void OnCardSelected(SelectEnterEventArgs args)
    {
        if (!cartaMostrada)
        {
            Mostrar();
            GameManager.Instance.CartaSeleccionada(this);
        }
    }

    public void Mostrar()
    {
        rend.sharedMaterial = materialFrente;
        cartaMostrada = true;
    }

    public void Ocultar()
    {
        rend.sharedMaterial = materialDorso;
        cartaMostrada = false;
    }

    private void OnDestroy()
    {
        interactable.selectEntered.RemoveListener(OnCardSelected);
    }
}