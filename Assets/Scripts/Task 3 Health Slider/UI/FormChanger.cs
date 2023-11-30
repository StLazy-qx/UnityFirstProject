using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FormChanger : MonoBehaviour
{
    [SerializeField] private Transform _shapeTarget;
    [SerializeField] private Button _button;
    [SerializeField] private float _durationAnimation;
    [SerializeField] private float _valueSize;
    [SerializeField] private Color _eventColor;

    private int _numberRepeats = 2;
    private MeshRenderer _objectColor;
    private Vector3 _defaultSize;

    private void Start()
    {
        _objectColor = _shapeTarget.GetComponent<MeshRenderer>();
        _defaultSize = _shapeTarget.localScale;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ChangeForm);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ChangeForm);
    }

    public void ChangeForm()
    {
        if (_shapeTarget.localScale == _defaultSize)
        {
            _objectColor.material.DOColor(_eventColor, _durationAnimation).
                SetLoops(_numberRepeats, LoopType.Yoyo);
            _shapeTarget.transform.DOScale(_valueSize, _durationAnimation).
                SetLoops(_numberRepeats, LoopType.Yoyo);
        }
    }
}
