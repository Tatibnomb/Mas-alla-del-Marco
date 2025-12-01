using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CardSingleUI : MonoBehaviour
{
    private CardGroup cardGroup;

    [SerializeField] private Button cardBackButton;

    [SerializeField] private Image cardBackBackground;
    [SerializeField] private Image cardFrontBackground;
    [SerializeField] private Image cardFrontImage;

    [SerializeField] private GameObject cardBack;
    [SerializeField] private GameObject cardFront;

    private bool objectMatch;

    [Header("DoTween Animation")]
    [SerializeField] private Vector3 selectRotation = new Vector3(0, 180, 0);
    [SerializeField] private Vector3 deselectRotation = Vector3.zero;
    [SerializeField] private float duration = 0.25f;

    private Tweener[] tweener = new Tweener[2];

    private void Awake()
    {
        if (cardGroup == null)
        {
            cardGroup = transform.parent.GetComponent<CardGroup>();
        }
        cardGroup?.Subscribe(this);
    }

    private void Start()
    {
        cardBackButton.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        if (!objectMatch)
            cardGroup.OnCardSelected(this);
    }

    public void Select()
    {
        tweener[0] = transform.DORotate(selectRotation, duration)
            .SetEase(Ease.InOutQuad)
            .OnUpdate(CheckSelectHalfDuration);
    }

    public void Deselect()
    {
        tweener[1] = transform.DORotate(deselectRotation, duration)
            .SetEase(Ease.InOutQuad)
            .OnUpdate(CheckDeselectHalfDuration);
    }

    private void CheckSelectHalfDuration()
    {
        if (tweener[0].Elapsed() >= tweener[0].Duration() / 2f)
        {
            cardBack.SetActive(false);
            cardFront.SetActive(true);
        }
    }

    private void CheckDeselectHalfDuration()
    {
        if (tweener[1].Elapsed() >= tweener[1].Duration() / 2f)
        {
            cardFront.SetActive(false);
            cardBack.SetActive(true);
        }
    }

    public void SetObjectMatch() => objectMatch = true;

    public bool GetObjectMatch() => objectMatch;

    public void DisableCardBackButton() => cardBackButton.interactable = false;

    public Image GetCardFrontBackground() => cardFrontBackground;

    public Image GetCardBackBackground() => cardBackBackground;
}