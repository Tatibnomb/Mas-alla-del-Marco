using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public List<CardUI> allCards = new List<CardUI>();
    public float revealDelay = 1.2f;

    private CardUI firstCard;
    private CardUI secondCard;

    public void CardSelected(CardUI card)
    {
        if (firstCard == null)
        {
            firstCard = card;
            return;
        }

        if (secondCard == null)
        {
            secondCard = card;
            StartCoroutine(CheckMatch());
        }
    }

    private IEnumerator CheckMatch()
    {
        yield return new WaitForSeconds(revealDelay);

        if (firstCard.cardID == secondCard.cardID)
        {
            firstCard.SetMatched();
            secondCard.SetMatched();
        }
        else
        {
            firstCard.HideCard();
            secondCard.HideCard();
        }

        firstCard = null;
        secondCard = null;
    }
}