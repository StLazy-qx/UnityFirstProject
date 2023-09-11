using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _valueDamage;
    [SerializeField] private float _valueHeal;
    [SerializeField] private UnityEvent _onClickButtonDamage;
    [SerializeField] private UnityEvent _onClickButtonHeal;

    private float _currentHealth;
    private float _durationMoveSlider = 2f;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        _healthSlider.DOValue(_currentHealth, _durationMoveSlider);

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
        }

        if (_currentHealth >= _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }

    public void TakeDamage()
    {
        if (_currentHealth != 0)
        {
            _currentHealth -= _valueDamage;

            _onClickButtonDamage.Invoke();
        }
    }

    public void TakeHeal()
    {
        if (_currentHealth != _maxHealth)
        {
            _currentHealth += _valueHeal;

            _onClickButtonHeal.Invoke();
        }
    }
}