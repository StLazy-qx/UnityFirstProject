using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstantiate: MonoBehaviour
{
    [SerializeField] private Vector3[] _spawnPoints;
    [SerializeField] private  GameObject _template;
    [SerializeField] private int _maxAngle;

    private int _numberPoint;
    private int _angleRotation;

    

    private void Update()
    {
        _numberPoint = Random.Range(0, _spawnPoints.Length);
        _angleRotation = Random.Range(0, _maxAngle);
        GameObject newTemplate = Instantiate(_template, _spawnPoints[_numberPoint], Quaternion.Euler(0, _angleRotation, 0));


    }

}
