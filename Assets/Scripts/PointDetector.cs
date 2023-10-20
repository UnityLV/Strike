﻿using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PointDetector : MonoBehaviour
{
    [SerializeField] private TMP_Text _counterText;
    public DefeatSystem DefeatSystem;
    public int Points => Game.Instance.LevelGoal.Points;

    private void Start()
    {
        UpdatePoints();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Target point))
        {
            if (Game.Instance != null)
            {
                Game.Instance.LevelGoal.AddPoints(1);
            }
          
            UpdatePoints();
            point.SplashEffect();
            Destroy(other.gameObject);
        }

        if (other.transform.TryGetComponent(out Enemy enemy))
        {
            Debug.Log("Enemy hit home");
            DefeatSystem.Defeat(600);
            Destroy(other.gameObject);
        }
    }

    private void UpdatePoints()
    {
        if (Game.Instance == null)
        {
            return;
        }
        int targetPoints = Game.Instance.LevelGoal.Goal;
        _counterText.text = $"Points: {Points}/{targetPoints}";
    }
}