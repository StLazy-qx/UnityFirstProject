using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FormChanger : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _durationAnimation;
    [SerializeField] private float _valueChangeSize;
    [SerializeField] private int _numberRepeats;
    [SerializeField] private Color _eventColor;

    private MeshRenderer _objectColor;
    private Color _defaultColor;
    private Vector3 _defaultSize;

    private void Start()
    {
        _objectColor = _target.GetComponent<MeshRenderer>();
        _defaultColor = _objectColor.material.color;
        _defaultSize = _target.localScale;
    }

    private void FixedUpdate()
    {
        _objectColor.material.color = _defaultColor;
        _target.localScale = _defaultSize;
    }

    public void ChangeForm()
    {
        _objectColor.material.DOColor(_eventColor, _durationAnimation).SetLoops(_numberRepeats, LoopType.Yoyo);
        _target.transform.DOScale(_valueChangeSize, _durationAnimation).SetLoops(_numberRepeats, LoopType.Yoyo);
    }
}
