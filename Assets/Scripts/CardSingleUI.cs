using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardSingleUI : MonoBehaviour, IPointerClickHandler
{
    public Image cardFrontImage;
    public Image cardBackImage;

    [Header("Sprites")]
    public Sprite frontSprite; // Imagen única
    public Sprite backSprite;  // Mismo dorso para todas

    public int pairID; // Identificador del par

    private bool isRevealed = false;
    private CardGroup group;

    private void Start()
    {
        // asignamos las imágenes
        cardFrontImage.sprite = frontSprite;
        cardBackImage.sprite = backSprite;

        group = FindObjectOfType<CardGroup>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isRevealed)
            Reveal();
    }

    public void Reveal()
    {
        isRevealed = true;
        cardFrontImage.gameObject.SetActive(true);
        cardBackImage.gameObject.SetActive(false);
        group.SelectCard(this);
    }

    public void Hide()
    {
        isRevealed = false;
        cardFrontImage.gameObject.SetActive(false);
        cardBackImage.gameObject.SetActive(true);
    }
}