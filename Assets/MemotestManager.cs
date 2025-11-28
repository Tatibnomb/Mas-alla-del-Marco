using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MemotestManager : MonoBehaviour
{
    public GameObject cardPrefab;
    public Transform gridParent;
    public Sprite[] images;        // imágenes de los cuadros
    public string[] names;         // nombres para emparejar

    private List<Card> selectedCards = new List<Card>();

    private void Start()
    {
        GenerateCards();
        gameObject.SetActive(false); // oculto al inicio
    }

    void GenerateCards()
    {
        List<int> ids = new List<int>();
        for (int i = 0; i < images.Length; i++) ids.Add(i);
        for (int i = 0; i < names.Length; i++) ids.Add(i);

        // Mezclar
        for (int i = 0; i < ids.Count; i++)
        {
            int rnd = Random.Range(0, ids.Count);
            (ids[i], ids[rnd]) = (ids[rnd], ids[i]);
        }

        foreach (int id in ids)
        {
            GameObject newCard = Instantiate(cardPrefab, gridParent);
            Card card = newCard.GetComponent<Card>();

            if (id < images.Length)
                card.Setup(id, images[id], false);   // imagen
            else
                card.Setup(id - images.Length, null, true); // texto
        }
    }

    public void CardSelected(Card card)
    {
        if (selectedCards.Contains(card)) return;

        selectedCards.Add(card);

        if (selectedCards.Count == 2)
        {
            if (selectedCards[0].pairID == selectedCards[1].pairID)
            {
                selectedCards[0].Correct();
                selectedCards[1].Correct();
            }
            else
            {
                selectedCards[0].Hide();
                selectedCards[1].Hide();
            }
            selectedCards.Clear();
        }
    }
}