using System;
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private Transform _targetPoints;
    [SerializeField] private Enemy[] _templates;

    private float _timeTemplateSpawn = 7.0f;
    private int _lifeTime = 9;
    private Transform[] _points;
    private Transform[] _targets;

    private void Start()
    {
        _points = new Transform[_spawnPoints.childCount];
        _targets = new Transform[_targetPoints.childCount];

        for (int i = 0; i < _spawnPoints.childCount; i++)
        {
            _points[i] = _spawnPoints.GetChild(i);
            _targets[i] = _targetPoints.GetChild(i);
        }

        StartCoroutine(CycleCreateEnemy());
    }

    private IEnumerator CycleCreateEnemy()
    {
        while (true)
        {
            for (int i = 0; i < _points.Length; i++)
            {
                var newTemplate = Instantiate(_templates[i], _points[i].position, Quaternion.identity);
                newTemplate.SetTargetPosition(_targets[i]);

                Destroy(newTemplate.gameObject, _lifeTime);
            }

            yield return new WaitForSeconds(_timeTemplateSpawn);
        }
    }
}