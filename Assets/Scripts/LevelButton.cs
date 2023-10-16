using System;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class LevelSettings
{
    public int Level = 1;
    public int Goal = 10;
}

[RequireComponent(typeof(Button))]
public class LevelButton : MonoBehaviour
{
    [SerializeField] private LevelSettings _settings;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(LoadLevel);
    }

    private void OnDestroy()
    {
        GetComponent<Button>().onClick.RemoveAllListeners();
    }

    private void LoadLevel()
    {
        Game.Instance.LoadLevel(_settings);
    }
}