﻿using UnityEngine;

public class StickyEffect : MonoBehaviour
{
    
    [SerializeField] private GameObject _target;
    private void OnEnable()
    {
        transform.parent = null;
    }

    private void Update()
    {
        if (_target == null)
        {
            return;
        }
        transform.position = _target.transform.position;
    }
}