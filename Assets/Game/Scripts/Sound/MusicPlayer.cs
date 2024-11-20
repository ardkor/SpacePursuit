using ChrisTutorials.Persistent;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip _musicClip;

     private AudioSource _musicSource;

    private void Start()
    {
         _musicSource = AudioManager.Instance.PlayLoop(_musicClip, transform, 1f, 1f, true);
    }
    public void TryPauseMusic()
    {
        if (_musicSource != null)
        {
            _musicSource.Pause();
        }
    }
    public void TryContinueMusic()
    {
        if (_musicSource != null)
        {
            _musicSource.Play();
        }
    }
}
