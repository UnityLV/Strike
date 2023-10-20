using System.Threading.Tasks;
using UnityEngine;

public class BounceEffect : MonoBehaviour
{
    [SerializeField] private GameObject _hitEffect;
    private Transform _collideWith;
    private bool _isHit = false;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.TryGetComponent(out Bounce _))
        {
            _collideWith = other.transform;
            HitEffect(other.GetContact(0).point);
        }
    }

    private async void HitEffect(Vector3 position)
    {
        if (_isHit)
        {
            return;
        }

        _isHit = true;
        var effect = Instantiate(_hitEffect, position, Quaternion.identity, _collideWith);
        Destroy(effect, 3);
        await Task.Delay(10);
        _isHit = false;
    }
}