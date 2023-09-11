using System;
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private TemplateBehavior _template;
    [SerializeField] private float _timeTemplateSpawn;
    [SerializeField] private int _lifeTime;
    [SerializeField] private int _maxAngle;

    private Transform[] _points;
    private int _numberPoint;
    private int _angleRotation;

    private void Start()
    {
        _points = new Transform[_spawnPoints.childCount];

        for (int i = 0; i < _spawnPoints.childCount; i++)
        {
            _points[i] = _spawnPoints.GetChild(i);
        }

        StartCoroutine(CycleCrateEnemmy());
    }

    private IEnumerator CycleCrateEnemmy()
    {
        while (true)
        {
            _numberPoint = UnityEngine.Random.Range(0, _spawnPoints.childCount);
            _angleRotation = UnityEngine.Random.Range(0, _maxAngle);
            TemplateBehavior newTemplate = Instantiate(_template,
                _points[_numberPoint].position, Quaternion.Euler(0, _angleRotation, 0));
            Destroy(newTemplate.gameObject, _lifeTime);

            yield return new WaitForSeconds(_timeTemplateSpawn);
        }
    }
}
