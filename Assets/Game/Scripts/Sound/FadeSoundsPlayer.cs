using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeSoundsPlayer : SoundsPlayer
{
    [SerializeField] protected float _rateTime = 0.1f;

    private bool _isCoroutineRunning = false;
    public void TryFadeSound()
    {
        if (!_isCoroutineRunning)
        {
            StartCoroutine(FadeSound());
            _isCoroutineRunning = true;
        }
    }

    public void TryIncreaseSound()
    {
        if (!_isCoroutineRunning)
        {
            TryContinue();
            StartCoroutine(IncreaseSound());
            _isCoroutineRunning = true;
        }
    }

    IEnumerator FadeSound()
    {
        float fadeTime = _rateTime;

        while (fadeTime > 0)
        {
            yield return null;
            fadeTime -= Time.deltaTime;
            _audioSource.volume -= _prevVolume * Time.deltaTime / _rateTime;
        }
        TryPause();
        _isCoroutineRunning = false;
        yield break;
    }

    IEnumerator IncreaseSound()
    {
        float increaseTime = 0;

        while (increaseTime < _rateTime)
        {
            yield return null;
            increaseTime += Time.deltaTime;
            _audioSource.volume += _prevVolume * Time.deltaTime / _rateTime;
        }
        _isCoroutineRunning = false;
        yield break;
    }
}
