﻿using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _targetPrefab;
    [SerializeField] private float _forceMagnitude = 1f;
    [SerializeField] private Vector2 _direction;
    [SerializeField] private float _spawnRate = 1f;
    [SerializeField] private float _offset;

    private void Start()
    {
        StartCoroutine(SpawnTarget());
    }

    private IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(_spawnRate, _spawnRate  + _offset));
            Rigidbody2D targetInstance = Instantiate(_targetPrefab, transform.position, Quaternion.identity);
            targetInstance.AddForce(_direction * _forceMagnitude, ForceMode2D.Impulse);
        }
       
    }
}