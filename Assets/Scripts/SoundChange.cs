using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]

public class SoundChange : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;
    [SerializeField] private float _maxVolume;
    [SerializeField] private float _minVolume;
    [SerializeField] private float _duration;

    private void Start()
    {
        _sound = GetComponent<AudioSource>();
        _sound.volume = 0;
    }

    public void IncreaseSound()
    {
        _sound.Stop();
        _sound.DOFade(_maxVolume, _duration);
        _sound.Play();
    }

    public void DecreaseSound()
    {
        _sound.Stop();
        _sound.DOFade(_minVolume, _duration);
        _sound.Play();
    }
}