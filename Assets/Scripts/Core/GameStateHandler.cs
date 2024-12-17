using UnityEngine;

public class GameStateHandler : MonoBehaviour
{
    public event System.Action OnGameStarted;
    public event System.Action OnLevelCompleted;
    public event System.Action OnGameCompleted;
    private void Start()
    {
        StartGame();
    }
    public void StartGame()
    {
        OnGameStarted?.Invoke();
    }

    public void CompletedLevel()
    {
        OnLevelCompleted?.Invoke();
    }

    public void CompleteGame()
    {
        OnGameCompleted?.Invoke();
    }
}