using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class WinSystem : MonoBehaviour
{
    [SerializeField] private UnityEvent _onVictory;
    public DefeatSystem DefeatSystem;
    private void OnEnable()
    {
        Game.Instance.LevelLoader.LevelCompleted += Win;
    }

    private void OnDisable()
    {
        Game.Instance.LevelLoader.LevelCompleted -= Win;
    }

    public async void Win()
    {
        DefeatSystem.DisableALL();
        await Task.Delay(200);
        _onVictory.Invoke();
    }
}