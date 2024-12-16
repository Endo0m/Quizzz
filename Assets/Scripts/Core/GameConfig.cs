using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Quiz/Game Config")]
public class GameConfig : ScriptableObject
{
    public LevelSettings[] Levels;
    public CardBundleData LettersBundle;
    public CardBundleData NumbersBundle;
    public float CellSpacing = 1.2f;
    public float CardBounceScale = 1.2f;
    public float CardBounceDuration = 0.3f;
    public float FadeDuration = 0.5f;
}