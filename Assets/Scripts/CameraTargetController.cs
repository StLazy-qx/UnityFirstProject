using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetController : MonoBehaviour
{
    [SerializeField] private float _camPositionSpeed;
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;

    private Vector3 _currentPosition;

    private void Start()
    {
        _currentPosition = _offset;
    }

    private void FixedUpdate()
    {
        _currentPosition = _target.position + _offset;
        transform.position = Vector3.Lerp(transform.position, _currentPosition, _camPositionSpeed * Time.deltaTime);
    }
}
