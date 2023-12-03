using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoverTarget : MonoBehaviour
{
    [SerializeField] private float _perimeterLength = 10f;
    [SerializeField] private float _duration = 3.0f;

    private Vector3 _initialPosition;
    private Vector3[] _perimeterPoints;
    private int _currentPoint;

    private void Start()
    {
        _initialPosition = transform.position;
        _perimeterPoints = new Vector3[]
        {
            new Vector3(_initialPosition.x + _perimeterLength, _initialPosition.y, _initialPosition.z),
            new Vector3(_initialPosition.x + _perimeterLength, _initialPosition.y, _initialPosition.z + _perimeterLength),
            new Vector3(_initialPosition.x , _initialPosition.y, _initialPosition.z + _perimeterLength),
            new Vector3(_initialPosition.x , _initialPosition.y, _initialPosition.z ),
        };
    }

    private void Update()
    {
        Vector3 targetPosition = _perimeterPoints[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _duration * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            _currentPoint++;

            if (_currentPoint >= _perimeterPoints.Length)
            {
                _currentPoint = 0;
            }
        }
    }
}
