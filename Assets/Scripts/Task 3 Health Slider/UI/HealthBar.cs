using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _slider;

    private float _durationAnimation = 0.5f;

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
        _slider.maxValue = 1;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int value, int maxValue)
    {
        var currentHealth = (float)value / maxValue;
        _slider.DOValue(currentHealth, _durationAnimation);
    }
}
