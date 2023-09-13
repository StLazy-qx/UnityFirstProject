using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _damage = 10;
    [SerializeField] private float _heal = 10;
    [SerializeField] private UnityEvent _onClickButtonDamage;
    [SerializeField] private UnityEvent _onClickButtonHeal;

    private float _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public float Health => _currentHealth;

    public void TakeDamage()
    {
        if (_currentHealth <= 0)
            return;

        _currentHealth -= _damage;

        _onClickButtonDamage?.Invoke();
    }

    public void TakeHeal()
    {
        if (_currentHealth >= _maxHealth)
            return;

        _currentHealth += _heal;

        _onClickButtonHeal?.Invoke();
    }
}