using System;
using UnityEngine;
using Random = UnityEngine.Random;

public enum ScreenSide
{
    Top,
    Bottom,
    Left,
    Right
}

public class MoveAlongEdge : MonoBehaviour
{
    [SerializeField] private ScreenSide _side = ScreenSide.Top;
    [SerializeField] private float _speed;

    [SerializeField] private float _firstCutY = 1;
    [SerializeField] private float _secondCutY = 1;

    [SerializeField] private float _firstCutX = 1;
    [SerializeField] private float _secondCutX = 1;

    private Vector2 _firstPosition;
    private Vector2 _secondPosition;

    private void Start()
    {
        
        _speed += Random.Range(-0.2f, 0.2f);
        float halfHeight = Camera.main.orthographicSize;
        float halfWidth = halfHeight * Camera.main.aspect;

        switch (_side)
        {
            case ScreenSide.Top:
                _firstPosition = new Vector2(-halfWidth, halfHeight);
                _secondPosition = new Vector2(halfWidth, halfHeight);
                break;
            case ScreenSide.Bottom:
                _firstPosition = new Vector2(-halfWidth, -halfHeight);
                _secondPosition = new Vector2(halfWidth, -halfHeight);
                break;
            case ScreenSide.Left:
                _firstPosition = new Vector2(-halfWidth, -halfHeight);
                _secondPosition = new Vector2(-halfWidth, halfHeight);
                break;
            case ScreenSide.Right:
                _firstPosition = new Vector2(halfWidth, -halfHeight);
                _secondPosition = new Vector2(halfWidth, halfHeight);
                break;
        }

        _firstPosition = Camera.main.transform.TransformPoint(_firstPosition);
        _secondPosition = Camera.main.transform.TransformPoint(_secondPosition);

        _firstPosition.y /= _firstCutY;
        _secondPosition.y /= _secondCutY;

        _firstPosition.x /= _firstCutX;
        _secondPosition.x /= _secondCutX;
    }

    private void Update()
    {
        transform.position =
            Vector2.Lerp(_firstPosition, _secondPosition, Mathf.PingPong(Time.time * _speed, 1f));
    }
}