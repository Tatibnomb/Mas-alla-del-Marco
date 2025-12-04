using UnityEngine;
using System.Collections.Generic;

public class CardGroup : MonoBehaviour
{
    public List<CardSingleUI> allCards;
    public List<CardSingleUI> selectedCards = new List<CardSingleUI>();

    public float revealDelay = 1f;

    public void SelectCard(CardSingleUI card)
    {
        selectedCards.Add(card);

        if (selectedCards.Count == 2)
        {
            StartCoroutine(CheckPair());
        }
    }

    private System.Collections.IEnumerator CheckPair()
    {
        yield return new WaitForSeconds(revealDelay);

        if (selectedCards[0].pairID == selectedCards[1].pairID)
        {
            // Par correcto → dejarlas reveladas
            Debug.Log("Par correcto");
        }
        else
        {
            // Par incorrecto → ocultar
            selectedCards[0].Hide();
            selectedCards[1].Hide();
        }

        selectedCards.Clear();
    }
}