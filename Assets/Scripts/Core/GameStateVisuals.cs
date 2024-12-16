    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class GameStateVisuals : MonoBehaviour
    {
        [SerializeField] private RestartButton restartButton;
        [SerializeField] private ScreenFader screenFader;
        [SerializeField] private LoadingScreen loadingScreen;
        [SerializeField] private GameStateHandler gameState;
        [SerializeField] private GridSpawner gridSpawner;

    private void OnEnable()
        {
            gameState.OnGameCompleted += HandleGameCompleted;
        }

        private void OnDisable()
        {
            gameState.OnGameCompleted -= HandleGameCompleted;
        }

        private void HandleGameCompleted()
        {
            if (gridSpawner != null)
            {
                gridSpawner.SetCardsInteractable(false);
            }
            screenFader.FadeToPartial();
            restartButton.Show();
        }

        public void HandleRestart()
        {
            if (gridSpawner != null)
            {
                gridSpawner.SetCardsInteractable(true);
            }
            screenFader.FadeOut();
            restartButton.Hide();
            loadingScreen.Show(() => gameState.StartGame());
        }
    }