using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    [SerializeField] private float _bounceForce = 10f;

    private void OnCollisionEnter2D(Collision2D other)
    {
        BounceOf(other);
    }

    private void BounceOf(Collision2D other)
    {
        Rigidbody2D rb = other.rigidbody;
        if (rb != null)
        {
            Vector2 direction = other.transform.position - transform.position;
            rb.AddForce(direction.normalized * _bounceForce, ForceMode2D.Impulse);
        }
    }
}