using DG.Tweening;
using UnityEngine;
public class UIFader : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private GameConfig gameConfig;

    public void FadeIn()
    {
        canvasGroup.alpha = 0;
        canvasGroup.DOFade(1, gameConfig.FadeDuration);
    }

    public void FadeOut()
    {
        canvasGroup.DOFade(0, gameConfig.FadeDuration);
    }
}