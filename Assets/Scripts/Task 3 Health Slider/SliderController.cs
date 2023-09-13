using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

[RequireComponent(typeof(HealthController))]

public class SliderController : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private float _durationAnimation;

    private HealthController _healthController;

    private void Start()
    {
        _healthController = GetComponent<HealthController>();
    }

    private void Update()
    {
        _healthSlider.DOValue(_healthController.Health, _durationAnimation);
    }
}
