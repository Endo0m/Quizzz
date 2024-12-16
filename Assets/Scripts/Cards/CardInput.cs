using UnityEngine;
using System;

public class CardInput : MonoBehaviour
{
    private bool isInteractable = true;
    public event Action<CardView> OnCardClicked;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void OnMouseDown()
    {
        if (isInteractable)
        {
            var cardView = GetComponent<CardView>();
            OnCardClicked?.Invoke(cardView);
        }
    }

    public void SetInteractable(bool value)
    {
        isInteractable = value;
        boxCollider.enabled = value;
    }
}