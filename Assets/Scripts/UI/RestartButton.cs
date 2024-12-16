using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RestartButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private CanvasGroup buttonGroup;
    [SerializeField] private GameStateVisuals gameStateVisuals; 

    private void Start()
    {
        Hide();
        button.onClick.AddListener(OnRestartClicked);
    }

    private void OnRestartClicked()
    {
        gameStateVisuals.HandleRestart();
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(OnRestartClicked);
    }

    public void Show()
    {
        buttonGroup.DOFade(1f, 0.5f);
        button.interactable = true;
    }

    public void Hide()
    {
        buttonGroup.DOFade(0f, 0.5f);
        button.interactable = false;
    }
}