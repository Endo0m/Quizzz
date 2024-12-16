using UnityEngine;

[CreateAssetMenu(fileName = "CardBundle", menuName = "Quiz/Card Bundle")]
public class CardBundleData : ScriptableObject
{
    public CardData[] Cards;
}