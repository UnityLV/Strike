using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; }

    public LevelSettings CurrentsSettings { get; private set; }

    public void LoadLevel(LevelSettings settings)
    {
        CurrentsSettings = settings;
        SceneManager.LoadScene("Game");
    }

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