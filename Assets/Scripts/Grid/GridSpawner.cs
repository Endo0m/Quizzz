using System.Collections.Generic;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Transform gridContainer;
    [SerializeField] private GameConfig gameConfig;
    private List<CardView> activeCards = new List<CardView>();
    private LevelInitializer levelInitializer;

    private void Awake()
    {
        levelInitializer = GetComponent<LevelInitializer>();
    }


    public void CreateGrid(LevelSettings settings, List<CardData> cardDataList)
    {
        if (cardPrefab == null || gridContainer == null || gameConfig == null)
        {
            Debug.LogError("Missing required references in GridSpawner!");
            return;
        }

        ClearGrid();

        float startX = -(settings.Columns - 1) * gameConfig.CellSpacing / 2;
        float startY = (settings.Rows - 1) * gameConfig.CellSpacing / 2;

        int cardIndex = 0;
        for (int row = 0; row < settings.Rows; row++)
        {
            for (int col = 0; col < settings.Columns; col++)
            {
                Vector3 position = new Vector3(
                    startX + col * gameConfig.CellSpacing,
                    startY - row * gameConfig.CellSpacing,
                    0
                );

                GameObject cardObject = Instantiate(cardPrefab, position, Quaternion.identity, gridContainer);
                CardView cardView = cardObject.GetComponent<CardView>();
                CardInput cardInput = cardObject.GetComponent<CardInput>();

                if (cardView != null && cardInput != null)
                {
                    cardView.Initialize(cardDataList[cardIndex]);
                    cardInput.OnCardClicked += levelInitializer.HandleCardSelected;

                    var animator = cardObject.GetComponent<CardAnimator>();
                    if (animator != null)
                    {
                        animator.PlaySpawnAnimation();
                    }
                    else
                    {
                        Debug.LogError("CardAnimator component not found on spawned card!");
                    }

                    activeCards.Add(cardView);
                }
                else
                {
                    Debug.LogError("Required components not found on spawned card!");
                }

                cardIndex++;
            }
        }
    }

    private void ClearGrid()
    {
        foreach (var card in activeCards)
        {
            if (card != null)
            {
                var cardInput = card.GetComponent<CardInput>();
                if (cardInput != null)
                {
                    cardInput.OnCardClicked -= levelInitializer.HandleCardSelected;
                }
                Destroy(card.gameObject);
            }
        }
        activeCards.Clear();
    }

    public void SetCardsInteractable(bool interactable)
    {
        foreach (var card in activeCards)
        {
            if (card != null)
            {
                var cardInput = card.GetComponent<CardInput>();
                if (cardInput != null)
                {
                    cardInput.SetInteractable(interactable);
                }
            }
        }
    }

    private void OnDestroy()
    {
        ClearGrid();
    }
}