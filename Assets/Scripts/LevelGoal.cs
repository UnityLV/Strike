using System;
using UnityEngine.Events;

public class LevelGoal
{
    private Action _reachCallback;
    public int Goal { get; private set; }
    public int Points { get; private set; }

    public void AddPoints(int points)
    {
        if (IsGoadReached) return;
        Points += points;
        TryCompleteGoal();
    }
    
    public void Reset()
    {
        Points = 0;
    }

    private void TryCompleteGoal()
    {
        if (IsGoadReached)
        {
            _reachCallback?.Invoke();
        }
    }

    private bool IsGoadReached => Points >= Goal;

    public void SetGoal(int goal, Action reachCallback)
    {
        Goal = goal;
        _reachCallback = reachCallback;
    }
}