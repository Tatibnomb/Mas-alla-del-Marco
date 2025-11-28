using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int pairID;
    public Image imageHolder;
    public GameObject textHolder;
    public Button btn;

    private MemotestManager manager;

    public void Setup(int id, Sprite img, bool isText)
    {
        pairID = id;

        manager = FindObjectOfType<MemotestManager>();

        if (isText)
        {
            textHolder.SetActive(true);
            imageHolder.gameObject.SetActive(false);
        }
        else
        {
            imageHolder.sprite = img;
            imageHolder.gameObject.SetActive(true);
            textHolder.SetActive(false);
        }

        btn.onClick.AddListener(() => manager.CardSelected(this));
    }

    public void Correct()
    {
        btn.interactable = false;
    }
}