using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteCondition
{
    public bool IsThisLevelCompleted(int level)
    {
        return PlayerPrefs.GetInt($"{level}") == 1;
    }

    public bool IsThisLastUncompleted(int level)
    {
        int levels = 10;

        for (int i = 1; i <= levels; i++)
        {
            if (PlayerPrefs.GetInt($"{i}") == 0)
            {
                return i == level;
            }
        }

        return false;
    }
}