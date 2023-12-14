using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AudioAdjuster : MonoBehaviour
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
        StartCoroutine(FadeSound(_maxVolume));
    }

    public void DecreaseSound()
    {
        StartCoroutine(FadeSound(_minVolume));
    }

    private IEnumerator FadeSound(float targetVolume)
    {
        _sound.Stop();

        float startVolume = _sound.volume;
        float timer = 0;

        while (timer < _duration)
        {
            _sound.volume = Mathf.Lerp(startVolume, targetVolume, timer / _duration);
            timer += Time.deltaTime;

            if (_sound.isPlaying == false)
            {
                _sound.Play();
            }

            yield return null;
        }

        _sound.volume = targetVolume;

        if (targetVolume == _minVolume)
        {
            _sound.Stop();
        }
    }
}