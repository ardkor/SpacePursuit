using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using UnityEngine.Audio;

//using System.Collections;
using System.Collections.Generic;
using ChrisTutorials.Persistent;

public class VolumeSlider : MonoBehaviour
{
   // [SerializeField] private TMP_Text _volumeText;
    [SerializeField] private Slider _slider; //переделать реквайр компонент геткомпонент?

    //[SerializeField] bool _effectSlider;
/*    [EnableIf("_effectSlider")]
    [SerializeField] private AudioClip _audioClip;
    [Dropdown("_mixersValues")]*/
    [SerializeField] private string _audioChannelName;

    private List<string> _mixersValues { get { return new List<string>() { "MasterVolume", "MusicVolume", "SoundVolume" }; } }

    private bool _buttonHold;
    private AudioSource _audioSource;
    private void Start()
    {
        //Debug.Log(PlayerPrefs.GetInt(_audioChannelName, 50) );
        _slider.value = (float)PlayerPrefs.GetInt(_audioChannelName, 50)/100;
        SetSliderVolume();
        //_volumeText.text = "" + PlayerPrefs.GetInt(_audioChannelName, 50);
    }

    public void SliderTriggering(bool button) 
    {
        _buttonHold = button;
        SetSliderVolume();
        PlayerPrefs.SetInt(_audioChannelName, System.Convert.ToInt32(_slider.value * 100));

       /* if (_effectSlider)
        {
            if (_buttonHold)
                _audioSource = AudioManager.Instance.PlayLoop(_audioClip, transform, 1f, 1f, false);
            else
                Destroy(_audioSource.gameObject);
        }*/
        //_volumeText.text = "" + System.Convert.ToInt32(_slider.value * 100);

    }

    public void SliderMoving() 
    {
/*        if (_buttonHold)
        {*/
            SetSliderVolume();
            PlayerPrefs.SetInt(_audioChannelName, System.Convert.ToInt32(_slider.value * 100));
           // _volumeText.text = "" + System.Convert.ToInt32(_slider.value * 100); 
       // }
        
    }

    private void SetSliderVolume()
    {
        switch (_audioChannelName)
        {
            case "MasterVolume":
                AudioManager.Instance.SetVolume(AudioManager.AudioChannel.Master, System.Convert.ToInt32(_slider.value * 100));
                break;

            case "MusicVolume":
                AudioManager.Instance.SetVolume(AudioManager.AudioChannel.Music, System.Convert.ToInt32(_slider.value * 100));
                break;

            case "SoundVolume":
                AudioManager.Instance.SetVolume(AudioManager.AudioChannel.Sound, System.Convert.ToInt32(_slider.value * 100));
                break;
        }
    }
}


