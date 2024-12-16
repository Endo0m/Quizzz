using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup loadingGroup;
    private void Awake()
    {
        // Убедимся что начинаем с скрытого состояния
        if (loadingGroup != null)
        {
            loadingGroup.alpha = 0;
        }
    }
    public void Show(Action onComplete)
    {
        var sequence = DOTween.Sequence();
        sequence.Append(loadingGroup.DOFade(1f, 0.3f));
        sequence.AppendInterval(0.5f);
        sequence.Append(loadingGroup.DOFade(0f, 0.3f));
        sequence.OnComplete(() => onComplete?.Invoke());
    }
}