using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScreenFader : MonoBehaviour
{
    [SerializeField] private Image fadeOverlay;
    private const float PARTIAL_FADE_ALPHA = 0.7f;

    private void Awake()
    {
        if (fadeOverlay != null)
        {
            fadeOverlay.color = new Color(0, 0, 0, 0);
        }
    }

    public void FadeToPartial()
    {
        fadeOverlay.DOFade(PARTIAL_FADE_ALPHA, 0.5f);
    }

    public void FadeOut()
    {
        fadeOverlay.DOFade(0f, 0.5f);
    }
}