using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _targetPrefab;
    [SerializeField] private float _forceMagnitude = 1f;
    [SerializeField] private float _coneAngle = 45f;
    [SerializeField] private float _spawnRate = 1f;
    [SerializeField] private float _offset;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnTarget), _offset + 1, _spawnRate + _offset);
    }

    private void SpawnTarget()
    {
        Rigidbody2D targetInstance = Instantiate(_targetPrefab, transform.position, Quaternion.identity);
        Vector2 forceDirection = CalculateForceDirection();
        targetInstance.AddForce(forceDirection * _forceMagnitude, ForceMode2D.Impulse);
    }

    private Vector2 CalculateForceDirection()
    {
        Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        Vector2 worldCenter = Camera.main.ScreenToWorldPoint(screenCenter);
        Vector2 direction = (worldCenter - (Vector2)transform.position).normalized;

        float randomAngle = Random.Range(-_coneAngle / 2, _coneAngle / 2);
        float radians = randomAngle * Mathf.Deg2Rad;
        float cos = Mathf.Cos(radians);
        float sin = Mathf.Sin(radians);

        Vector2 rotatedDirection = new Vector2(
            direction.x * cos - direction.y * sin,
            direction.x * sin + direction.y * cos
        );

        return rotatedDirection;
    }
}