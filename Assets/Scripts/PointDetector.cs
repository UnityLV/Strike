using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PointDetector : MonoBehaviour
{
    [SerializeField] private GameObject _deadEffect;
    [SerializeField] private TMP_Text _counterText;
    public DefeatSystem DefeatSystem;
    public int Points => Game.Instance.LevelGoal.Points;

    private void Start()
    {
        if (Game.Instance != null)
        {
            Game.Instance.LevelGoal.Reset();
        }

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
            Vector2 collisionPoint = other.ClosestPoint(transform.position);
            ShowDeadParticles(collisionPoint);
            
            DefeatSystem.Defeat(900);
            
            Destroy(other.gameObject);
        }
    }

    private void ShowDeadParticles(Vector3 point)
    {
        var effect = Instantiate(_deadEffect, point, Quaternion.identity);
        Destroy(effect, 5);
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