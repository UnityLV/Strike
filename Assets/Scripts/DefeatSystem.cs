using System;
using System.Linq;
using System.Threading.Tasks;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

public class DefeatSystem : MonoBehaviour
{
    [SerializeField] private UnityEvent _onDefeat;
   

    [Button()]
    public async void Defeat(int delay = 200)
    {
        DisableALL();
        await Task.Delay(delay);
        _onDefeat.Invoke();
    }

    public void DisableALL()
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
    }

    private void Disable(params Component[] components)
    {
        foreach (var component in components)
        {
            Destroy(component);
        }
    }
}

