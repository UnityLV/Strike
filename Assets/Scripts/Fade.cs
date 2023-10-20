using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;

public class Fade : MonoBehaviour
{
    [SerializeField] private float _durationIn = 1f;
    [SerializeField] private float _durationOut = 1f;
    [SerializeField] private CanvasGroup _canvasGroup;
    

    public void FadeIn()
    {
        _canvasGroup.DOKill();
        _canvasGroup.DOFade(1f, _durationIn);
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }

    public void FadeOut()
    {
        _canvasGroup.DOKill();
        _canvasGroup.DOFade(0f, _durationOut);
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }
}