using System.Linq;
using System.Threading.Tasks;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

public class DefeatSystem : MonoBehaviour
{
    [SerializeField] private UnityEvent _onDefeat;
    [SerializeField] private UnityEvent _onVictory;

    [Button()]
    public async void Defeat()
    {
        var allEnemySpawners = FindObjectsOfType<EnemySpawner>();
        var allTargetSpawners = FindObjectsOfType<TargetSpawner>();
        var allRigidBody2Ds = FindObjectsOfType<Rigidbody2D>();
        var controllers = FindObjectsOfType<PaddleController>();
        var allMove = FindObjectsOfType<MoveAlongEdge>();

        Disable(allEnemySpawners);
        Disable(allTargetSpawners);
        Disable(allRigidBody2Ds);
        Disable(controllers);
        Disable(allMove);
        await Task.Delay(200);
        _onDefeat.Invoke();
    }
    [Button()]
    public void Victory()
    {
        
        _onVictory.Invoke();
    }
  

    private void Disable(params Component[] components)
    {
        foreach (var component in components)
        {
            Destroy(component);
        }
    }
}

