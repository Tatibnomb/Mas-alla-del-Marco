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

    [Header("Separación al voltear")]
    public float separacion = 0.3f;
    public float duracionMovimiento = 0.25f;

    private MeshRenderer rend;
    private bool cartaMostrada = false;

    private Vector3 posicionOriginal;

    private XRSimpleInteractable interactable;

    private void Awake()
    {
        rend = GetComponentInChildren<MeshRenderer>();
        interactable = GetComponent<XRSimpleInteractable>();
        posicionOriginal = transform.localPosition;
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

        StopAllCoroutines();
        StartCoroutine(MoverCarta(posicionOriginal + ObtenerOffset()));
    }

    public void Ocultar()
    {
        rend.sharedMaterial = materialDorso;
        cartaMostrada = false;

        StopAllCoroutines();
        StartCoroutine(MoverCarta(posicionOriginal));
    }

    private Vector3 ObtenerOffset()
    {
        float direccion = transform.localPosition.x >= 0 ? 1f : -1f;
        return new Vector3(separacion * direccion, 0, 0);
    }

    private IEnumerator MoverCarta(Vector3 destino)
    {
        Vector3 inicio = transform.localPosition;
        float t = 0;

        while (t < duracionMovimiento)
        {
            t += Time.deltaTime;
            float lerp = t / duracionMovimiento;
            transform.localPosition = Vector3.Lerp(inicio, destino, lerp);
            yield return null;
        }

        transform.localPosition = destino;
    }

    private void OnDestroy()
    {
        interactable.selectEntered.RemoveListener(OnCardSelected);
    }
}