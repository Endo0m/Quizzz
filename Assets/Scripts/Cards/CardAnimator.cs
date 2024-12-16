using DG.Tweening;
using UnityEngine;

public class CardAnimator : MonoBehaviour
{
    private GameConfig config;
    private Transform cardTransform;
    private Tween scaleTween;
    private Tween shakeTween;

    private void Awake()
    {
        cardTransform = transform;
        config = Resources.Load<GameConfig>("GameConfig");
    }

    private void OnDestroy()
    {
        scaleTween?.Kill();
        shakeTween?.Kill();
    }

    public void PlayBounceAnimation()
    {
        if (config == null || cardTransform == null) return;

        scaleTween?.Kill();
        scaleTween = cardTransform.DOScale(config.CardBounceScale, config.CardBounceDuration)
            .SetEase(Ease.OutBounce)
            .OnComplete(() => {
                if (cardTransform != null)
                {
                    scaleTween = cardTransform.DOScale(1f, config.CardBounceDuration / 2);
                }
            });
    }

    public void PlayShakeAnimation()
    {
        if (config == null || cardTransform == null) return;

        shakeTween?.Kill();
        shakeTween = cardTransform.DOShakePosition(0.5f, 0.3f, 10, 90f);
    }

    public void PlaySpawnAnimation()
    {
        if (config == null || cardTransform == null) return;

        cardTransform.localScale = Vector3.zero;
        scaleTween?.Kill();
        scaleTween = cardTransform.DOScale(1f, config.CardBounceDuration)
            .SetEase(Ease.OutBounce);
    }
}