using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChrisTutorials.Persistent;

public class SoundsPlayer : MonoBehaviour
{
    [SerializeField] protected Sound[] _sounds;

    protected AudioClip _audioClip;
    protected AudioSource _audioSource;
    protected float _prevVolume;

    [SerializeField] protected float rateTime = 0.01f;

    public void FadeSound()
    {
        
/*        _audioSource.volume = 0.1f;
        TryPause();*/
        StartCoroutine(_FadeSound());
    }

    public void IncreaseSound()
    {
        //_audioSource.volume = _prevVolume;
        TryContinue();
        StartCoroutine(_IncreaseSound());
    }

    IEnumerator _FadeSound()
    {
        float t = rateTime;

        while (t > 0)
        {
            yield return null;
            t -= Time.deltaTime;
            _audioSource.volume = t / rateTime;
        }
        TryPause();
        yield break;
        //yield audioSource.Pause ();
    }

    IEnumerator _IncreaseSound()
    {
        float t = 0;

        while (_audioSource.volume < 1)
        {
            yield return null;
            t += Time.deltaTime;
            _audioSource.volume = t / rateTime;
        }
        yield break;
    }

    [System.Serializable]
    protected class Sound
    {
        public string name;
        public AudioClip audioClip;
    }
    public void TryPause()
    {
        if (_audioSource != null)
        {
            _audioSource.Pause();
        }
    }
    public void TryContinue()
    {
        if (_audioSource != null)
        {
            _audioSource.Play();
        }
    }
    private void FindClip(string name)
    {
        foreach (Sound sound in _sounds)
        {
            if (sound.name == name)
            {
                _audioClip = sound.audioClip;
                return;
            }
        }
    }
    public void Play(string name)
    {
        float pitch = Random.Range(0.8f, 1f);
        FindClip(name);
        if (_audioClip != null)
        {
            _audioSource = AudioManager.Instance.Play(_audioClip, transform, 1f, pitch);
        }
    }
    public void PlayVolumed(string name, float volume)
    {
        _prevVolume = volume;
        float pitch = Random.Range(0.8f, 1f);
        FindClip(name);
        if (_audioClip != null)
        {
            _audioSource = AudioManager.Instance.Play(_audioClip, transform, volume, pitch);
        }
    }
    public void PlayVolumedLoop(string name, float volume)
    {
        _prevVolume = volume;
        FindClip(name);
        if (_audioClip != null)
        {
            _audioSource = AudioManager.Instance.PlayLoop(_audioClip, transform, volume, 1f);
        }
    }
    public bool isPlaying()
    {
        return _audioSource.isPlaying;
    }
}
