using System.Threading.Tasks;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private GameObject _splashEffect;
    
    private async void Awake()
    {
        await Task.Delay(400);
        gameObject.layer = LayerMask.NameToLayer("Target");
    }

    public void SplashEffect()
    {
        var effect = Instantiate(_splashEffect, transform.position, Quaternion.identity);
        Destroy(effect, 4);
    }
}