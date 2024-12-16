using UnityEngine;

public class LevelSequence : MonoBehaviour
{
    [SerializeField] private LevelSequenceData sequenceData;
    private int currentIndex;

    public LevelSettings GetCurrentLevel() => sequenceData.Levels[currentIndex];
    public bool HasNextLevel() => currentIndex < sequenceData.Levels.Length - 1;
    public void MoveToNextLevel() => currentIndex++;
    public void ResetToFirst() => currentIndex = 0;
}