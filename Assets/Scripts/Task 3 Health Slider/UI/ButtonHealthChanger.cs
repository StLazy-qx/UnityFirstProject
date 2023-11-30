using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHealthChanger : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Player _player;
    [SerializeField] private int _changeHealthValue;

    private void OnEnable()
    {
        _button.onClick.AddListener(ChangeHealth);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ChangeHealth);
    }

    private void ChangeHealth()
    {
        _player.CheckHealthStatus(_changeHealthValue);
    }
}
