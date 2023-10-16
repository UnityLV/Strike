using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PointDetector : MonoBehaviour
{
    public int Points { get; private set; }
    [SerializeField] private TMP_Text _counterText;

    private void Start()
    {
        _counterText.text = $"Points: {Points}";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Point point))
        {
            Points++;
            _counterText.text = $"Points: {Points}";
            Destroy(other.gameObject);
        }
    }

}