using System;
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private Enemy _template;
    [SerializeField] private float _timeTemplateSpawn;
    [SerializeField] private int _lifeTime;
    [SerializeField] private int _maxAngle;

    private Transform[] _points;

    private void Start()
    {
        _points = new Transform[_spawnPoints.childCount];

        for (int i = 0; i < _spawnPoints.childCount; i++)
        {
            _points[i] = _spawnPoints.GetChild(i);
        }

        StartCoroutine(CycleCreateEnemy());
    }

    private IEnumerator CycleCreateEnemy()
    {
        while (true)
        {
            int randomIndex = UnityEngine.Random.Range(0, _spawnPoints.childCount);
            float randomAngle = UnityEngine.Random.Range(0, _maxAngle);
            var newTemplate = Instantiate(_template,_points[randomIndex].position, 
                Quaternion.Euler(0, randomAngle, 0));

            Destroy(newTemplate.gameObject, _lifeTime);

            yield return new WaitForSeconds(_timeTemplateSpawn);
        }
    }
}
