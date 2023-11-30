using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour 
{
    [SerializeField] private int _health;

    private int _currentHealth;

    public event UnityAction<int, int> HealthChanged;

    public float Health => _health;

    private void Start()
    {
        _currentHealth = _health;
    }

    public void CheckHealthStatus(int value)
    {
        _currentHealth += value;
        HealthChanged?.Invoke(_currentHealth,_health);

        if (_currentHealth <= 0)
            _currentHealth = 0;

        if(_currentHealth >= _health)
            _currentHealth = _health;
    }
}
