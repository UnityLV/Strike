using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _explodeOfWallEffect;

    public void ExplodeOfWall()
    {
        var effect = Instantiate(_explodeOfWallEffect, transform.position, Quaternion.identity);
        Destroy(effect, 4);
    }
}