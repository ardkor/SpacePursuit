/*using System.Collections;
using System.Collections.Generic;*/
using UnityEngine;
//using UnityEngine.Audio;
using ChrisTutorials.Persistent;

public class UIManager : MonoBehaviour
{

    //public AudioMixer masterMixer;
    //public AudioClip _audioClip;
    /*private void Start()
    {
       // Time.timeScale = 0f;

                int masterVolume = PlayerPrefs.GetInt("MasterVolume", 50);
                int soundVolume = PlayerPrefs.GetInt("SoundVolume", 50);
                int musicVolume = PlayerPrefs.GetInt("MusicVolume", 50);

                // Update the audio mixer

                masterMixer.SetFloat("MasterVolume", (float)masterVolume);
                masterMixer.SetFloat("SoundVolume", (float)soundVolume);
                masterMixer.SetFloat("MusicVolume", musicVolume);
}*/
    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void GoTime()
    {
        Time.timeScale = 1;
    }

    public void StopTime()
    {
        Time.timeScale = 0;
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void Test()
    {
        Debug.Log("button");
    }
}
