using UnityEngine;

public class CardView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer iconRenderer;
    private CardData data;
    private CardAnimator animator;
    private CardInput cardInput;

    private void Awake()
    {
        animator = GetComponent<CardAnimator>();
        cardInput = GetComponent<CardInput>();
        cardInput.OnCardClicked += HandleCardClicked;
    }

    private void OnDestroy()
    {
        if (cardInput != null)
            cardInput.OnCardClicked -= HandleCardClicked;
    }

    public void Initialize(CardData cardData)
    {
        data = cardData;
        iconRenderer.sprite = cardData.Icon;
        transform.localRotation = Quaternion.Euler(0, 0, cardData.Rotation);
    }

    private void HandleCardClicked(CardView cardView)
    {
        animator.PlayBounceAnimation();
    }

    public string GetValue() => data.Value;
}