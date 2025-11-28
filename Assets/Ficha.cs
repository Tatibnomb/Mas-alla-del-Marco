using UnityEngine;
using UnityEngine.UI;

public class Ficha : MonoBehaviour
{
    public int pairID;                   // ID del cuadro que representa
    public Image imageHolder;            // Imagen del cuadro (si corresponde)
    public GameObject textHolder;        // Texto del nombre (si corresponde)
    public Text textComponent;           // El texto dentro del textHolder
    public Button btn;                   // Botón para tocar la ficha

    private MemotestManager manager;     // Referencia al Manager

    // -------------------------------------------------------------
    // SETUP: se llama desde el Manager para configurar cada ficha
    // -------------------------------------------------------------
    public void Setup(int id, Sprite img, string texto, bool esTexto)
    {
        pairID = id;

        manager = FindObjectOfType<MemotestManager>();

        if (esTexto)
        {
            // Mostrar texto
            textHolder.SetActive(true);
            imageHolder.gameObject.SetActive(false);

            textComponent.text = texto;
        }
        else
        {
            // Mostrar imagen
            imageHolder.sprite = img;
            imageHolder.gameObject.SetActive(true);
            textHolder.SetActive(false);
        }

        // Cuando el usuario toca la ficha…
        btn.onClick.AddListener(() => manager.FichaSeleccionada(this));
    }

    // -------------------------------------------------------------
    // Cuando la ficha es correcta (match)
    // -------------------------------------------------------------
    public void Correct()
    {
        btn.interactable = false;
    }
}