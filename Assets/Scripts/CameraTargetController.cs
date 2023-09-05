using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetController : MonoBehaviour
{
    [SerializeField] private float _camPositionSpeed = 5f;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Vector3 _offset;

    private void FixedUpdate()
    {
        Vector3 newCamPosition = _playerTransform.position + _offset;
        transform.position = Vector3.Lerp(transform.position, newCamPosition, _camPositionSpeed * Time.deltaTime);
    }
}
