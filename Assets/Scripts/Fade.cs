using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;

public class Fade : MonoBehaviour
{
    [SerializeField] private float _durationIn = 1f;
    [SerializeField] private float _durationOut = 1f;
    
    [SerializeField] private float _delay;
    
    [SerializeField] private CanvasGroup _canvasGroup;
    

    public async void FadeIn()
    {
        await Task.Delay((int)(_delay * 1000));
        _canvasGroup.DOKill();
        _canvasGroup.DOFade(1f, _durationIn);
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }

    public async void FadeOut()
    {
        await Task.Delay((int)(_delay * 1000));
        _canvasGroup.DOKill();
        _canvasGroup.DOFade(0f, _durationOut);
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }
}