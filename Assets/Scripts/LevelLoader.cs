using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader
{
    public event Action LevelCompleted;
    public event Action StartLevelLoad;
    public LevelSettings CurrentsSettings { get; private set; }
    public async void LoadLevel(LevelSettings settings)
    {
        StartLevelLoad?.Invoke();
        await Task.Delay(300);
        CurrentsSettings = settings;
        Game.Instance.LevelGoal.SetGoad(settings.Goal, LevelComplete);
        SceneManager.LoadScene("Game");
    }

    private void LevelComplete()
    {
        PlayerPrefs.SetInt($"{CurrentsSettings.Level}", 1);
        LevelCompleted?.Invoke();
    }
}