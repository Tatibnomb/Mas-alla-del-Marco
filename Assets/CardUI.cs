using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    public Image frontImage;
    public GameObject backObject;
    public GameObject frontObject;

    private CardManager cardManager;
    public int cardID; // ID para comparar cartas

    public bool isRevealed = false;
    public bool isMatched = false;

    private void Start()
    {
        cardManager = FindObjectOfType<CardManager>();
    }

    // SE LLAMA CUANDO EL PLAYER LA TOCA (VR XR Simple Interactable)
    public void OnSelectCard()
    {
        if (isMatched) return;
        if (isRevealed) return;

        RevealCard();
        cardManager.CardSelected(this);
    }

    public void RevealCard()
    {
        isRevealed = true;
        backObject.SetActive(false);
        frontObject.SetActive(true);
    }

    public void HideCard()
    {
        isRevealed = false;
        frontObject.SetActive(false);
        backObject.SetActive(true);
    }

    public void SetMatched()
    {
        isMatched = true;
    }
}