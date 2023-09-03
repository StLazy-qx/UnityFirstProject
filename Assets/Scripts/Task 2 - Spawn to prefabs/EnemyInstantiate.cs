using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstantiate: MonoBehaviour
{
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private int _timeTemplateSpawn;
    [SerializeField] private int _lifeTime;
    [SerializeField] private  GameObject _template;
    [SerializeField] private int _maxAngle;


    private Transform[] _points;
    private int _numberPoint;
    private int _angleRotation;
    private float _currentTime;

    private void Start()
    {
        _points = new Transform[_spawnPoints.childCount];

        for (int i = 0; i < _spawnPoints.childCount; i++)
        {
            _points[i] = _spawnPoints.GetChild(i);
        }
    }

    private void Update()
    {
        _numberPoint = Random.Range(0, _spawnPoints.childCount);
        _angleRotation = Random.Range(0, _maxAngle);
        _currentTime += Time.deltaTime;

        if (_currentTime >= _timeTemplateSpawn)
        {
            GameObject newTemplate = Instantiate(_template, 
                _points[_numberPoint].position, Quaternion.Euler(0, _angleRotation, 0));
            _currentTime = 0;
            Destroy(newTemplate, _lifeTime);
        }
    }
}
