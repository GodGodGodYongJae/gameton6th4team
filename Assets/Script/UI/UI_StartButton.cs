using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_StartButton : MonoBehaviour
{
    RectTransform _ractTransform;
    void Start()
    {
        _ractTransform = GetComponent<RectTransform>();
        _ractTransform.localScale = Vector3.zero;
        ShowStartSequence();

    }

   private void ShowStartSequence()
    {
        var seq = DOTween.Sequence();
        seq.Append(_ractTransform.DOScale(1f, 0.5f).SetEase(Ease.InSine));
        seq.Play().OnComplete(() =>
        {
            BoundSequence();
        });
    }
    private void BoundSequence()
    {
        var seq = DOTween.Sequence();
        seq.Append(_ractTransform.DOScale(1.5f, 0.5f).SetEase(Ease.Linear));
        seq.Append(_ractTransform.DOScale(1f, 0.5f).SetEase(Ease.Linear));
        seq.Play().SetLoops(-1);
    }
}
