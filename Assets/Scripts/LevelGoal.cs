using System;
using UnityEngine.Events;

public class LevelGoal
{
    private Action ReachCallback { get; set; }
    public int Goal { get; private set; }
    public int Points { get; private set; }

    public void AddPoints(int points)
    {
        Points += points;
        TryCompleteGoal();
    }
    
    public void Reset()
    {
        Points = 0;
    }

    private void TryCompleteGoal()
    {
        if (Points >= Goal)
        {
            ReachCallback();
        }
    }

    public void SetGoal(int goal, Action reachCallback)
    {
        Goal = goal;
        ReachCallback = reachCallback;
    }
}