using UnityEngine;

public class LevelInitializer : MonoBehaviour
{
    [SerializeField] private LevelSequence levelSequence;
    [SerializeField] private CardSetGenerator cardSetGenerator;
    [SerializeField] private GridSpawner gridSpawner;
    [SerializeField] private TaskDisplay taskDisplay;
    [SerializeField] private GameStateHandler gameState;

    private string currentTarget;

    private void OnEnable()
    {
        gameState.OnGameStarted += InitializeFirstLevel;
        gameState.OnLevelCompleted += TryInitializeNextLevel;
    }

    private void OnDisable()
    {
        gameState.OnGameStarted -= InitializeFirstLevel;
        gameState.OnLevelCompleted -= TryInitializeNextLevel;
    }

    public void HandleCardSelected(CardView cardView)
    {
        if (cardView.GetValue() == currentTarget)
        {
            cardView.GetComponent<CardAnimator>().PlayBounceAnimation();
            gameState.CompletedLevel();
        }
        else
        {
            cardView.GetComponent<CardAnimator>().PlayShakeAnimation();
        }
    }

    private void InitializeFirstLevel()
    {
        levelSequence.ResetToFirst();
        InitializeLevel();
    }

    private void TryInitializeNextLevel()
    {
        if (levelSequence.HasNextLevel())
        {
            levelSequence.MoveToNextLevel();
            InitializeLevel();
        }
        else
        {
            gameState.CompleteGame();
        }
    }

    private void InitializeLevel()
    {
        var levelConfig = levelSequence.GetCurrentLevel();
        var (cards, target) = cardSetGenerator.GenerateCardSet(levelConfig.CellCount);
        currentTarget = target;

        gridSpawner.CreateGrid(levelConfig, cards);
        taskDisplay.SetTask($"Find {target}");
    }
}