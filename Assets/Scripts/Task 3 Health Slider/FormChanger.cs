using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FormChanger : MonoBehaviour
{
    [SerializeField] private float _durationAnimation;
    [SerializeField] private float _valueChangeSize;
    [SerializeField] private Color _eventColor;

    private int _numberRepeats = 2;
    private MeshRenderer _objectColor;
    private Color _defaultColor;
    private Vector3 _defaultSize;

    private void Start()
    {
        _objectColor = GetComponent<MeshRenderer>();
        _defaultColor = _objectColor.material.color;
        _defaultSize = transform.localScale;
    }

    private void Update()
    {
        _objectColor.material.color = _defaultColor;
        transform.localScale = _defaultSize;
    }

    public void ChangeForm()
    {
        _objectColor.material.DOColor(_eventColor, _durationAnimation).
            SetLoops(_numberRepeats, LoopType.Yoyo);
        transform.DOScale(_valueChangeSize, _durationAnimation).
            SetLoops(_numberRepeats, LoopType.Yoyo);
    }
}
