using System;

public class LevelGoal
{
    public Action ReachCallback { get; set; }
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

    public void SetGoad(int goal, Action reachCallback)
    {
        Points = 0;
        Goal = goal;
        ReachCallback = reachCallback;
    }
}