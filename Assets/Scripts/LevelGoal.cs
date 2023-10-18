using System;

public class LevelGoal
{
    public Action ReachCallback { get; set; }
    public int Goal { get; set; }
    public int Points { get; set; }

    public void AddPoints(int points)
    {
        Points += points;
        TryCompleteGoal();
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