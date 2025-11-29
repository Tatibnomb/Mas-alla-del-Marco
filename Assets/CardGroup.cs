using System.Collections.Generic;
using UnityEngine;
using System;

public class CardGroup : MonoBehaviour
{
    [SerializeField] private List<CardSingleUI> cardSingleUIList = new List<CardSingleUI>();
    [SerializeField] private List<CardSingleUI> selectedCardList = new List<CardSingleUI>();

    [SerializeField] private Sprite cardIdle;
    [SerializeField] private Sprite cardActive;

    public event EventHandler OnCardMatch;

    public void Subscribe(CardSingleUI cardSingleUI)
    {
        if (cardSingleUIList == null)
            cardSingleUIList = new List<CardSingleUI>();

        if (!cardSingleUIList.Contains(cardSingleUI))
            cardSingleUIList.Add(cardSingleUI);
    }

    public void OnCardSelected(CardSingleUI cardSingleUI)
    {
        if (selectedCardList.Count >= 2) return;

        selectedCardList.Add(cardSingleUI);

        cardSingleUI.Select();
        cardSingleUI.GetCardFrontBackground().sprite = cardActive;

        if (selectedCardList.Count == 2)
        {
            if (CheckIfMatch())
            {
                foreach (var card in selectedCardList)
                {
                    card.DisableCardBackButton();
                    card.SetObjectMatch();
                }
            }
            else
            {
                StartCoroutine(ResetCards());
            }
        }
    }

    private bool CheckIfMatch()
    {
        return selectedCardList[0].name == selectedCardList[1].name;
    }

    private System.Collections.IEnumerator ResetCards()
    {
        yield return new WaitForSeconds(1f);

        foreach (var card in selectedCardList)
        {
            card.Deselect();
        }

        selectedCardList.Clear();
    }
}