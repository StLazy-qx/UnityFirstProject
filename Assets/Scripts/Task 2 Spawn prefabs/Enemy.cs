using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour 
{
    private float _speedMove = 7.0f;
    private Transform _target;
    private Vector3 _targetLastPosition;

    private void Update()
    {
        if (_target != null)
        {
            Vector3 targetPosition = _target.position;

            if (_targetLastPosition != targetPosition)
            {
                Vector3 newPosition = Vector3.MoveTowards(transform.position, targetPosition, _speedMove * Time.deltaTime);
                transform.position = newPosition;
                _targetLastPosition = targetPosition;
            }
        }
    }

    public void SetTargetPosition(Transform target)
    {
        _target = target;
    }
}
