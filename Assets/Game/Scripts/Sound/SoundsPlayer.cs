using UnityEngine;
using ChrisTutorials.Persistent;

public class SoundsPlayer : MonoBehaviour
{
    [SerializeField] protected Sound[] _sounds;
    [SerializeField] protected bool _isDistantion = false;

    protected float _maxDistance = 10f;
    protected AudioClip _audioClip;
    protected AudioSource _audioSource;
    protected float _prevVolume;

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
        Play(name, 1f);
    }
    public void Play(string name, float volume)
    {
        Play(name, volume, 1f);
    }
    public void Play(string name, float volume, float pitch)
    {
        Play(name, volume, pitch, _maxDistance);
    }
    public void Play(string name, float volume, float pitch, float maxDistance)
    {
        _prevVolume = volume;
        FindClip(name);
        if (_audioClip != null)
        {
            _audioSource = AudioManager.Instance.Play(_audioClip, transform, volume, pitch);
        }
        if (_isDistantion)
        {
            _audioSource.rolloffMode = AudioRolloffMode.Linear;
            _audioSource.spatialBlend = 1f;
            _audioSource.maxDistance = maxDistance;
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
        if (_isDistantion)
        {
            _audioSource.rolloffMode = AudioRolloffMode.Linear;
            _audioSource.spatialBlend = 1f;
            _audioSource.maxDistance = _maxDistance;
        }
    }
    public bool IsPlaying()
    {
        return _audioSource.isPlaying;
    }
}
