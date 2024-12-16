using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardSetGenerator : MonoBehaviour
{
    [SerializeField] private CardBundleData[] bundles; 
    private HashSet<string> usedTargets = new HashSet<string>();

    public (List<CardData> cards, string target) GenerateCardSet(int cardCount)
    {
        var bundle = bundles[Random.Range(0, bundles.Length)];

        var availableCards = bundle.Cards.ToList();
        var selectedCards = new List<CardData>();

        while (selectedCards.Count < cardCount && availableCards.Count > 0)
        {
            int index = Random.Range(0, availableCards.Count);
            selectedCards.Add(availableCards[index]);
            availableCards.RemoveAt(index);
        }

        string target = SelectTarget(selectedCards);
        return (selectedCards, target);
    }

    private string SelectTarget(List<CardData> cards)
    {
        var unusedCards = cards.Where(c => !usedTargets.Contains(c.Value)).ToList();
        if (unusedCards.Count == 0)
        {
            usedTargets.Clear();
            return SelectTarget(cards);
        }

        var selected = unusedCards[Random.Range(0, unusedCards.Count)];
        usedTargets.Add(selected.Value);
        return selected.Value;
    }
}