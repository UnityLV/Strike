using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; }

    public readonly LevelCompleteCondition LevelCompleteCondition = new();
    public readonly LevelGoal LevelGoal = new();
    public readonly LevelLoader LevelLoader = new();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}