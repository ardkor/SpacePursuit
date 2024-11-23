using System;
using UnityEngine;
using UnityEngine.UI;

public class RetroModeManager : MonoBehaviour
{
    [SerializeField] private postVHSPro _postVHSPro;
    [SerializeField] private Toggle _toggle;

    private void Start()
    {
        _toggle.isOn = Convert.ToBoolean(PlayerPrefs.GetInt("isRetroMode", 0));
        _postVHSPro.enabled = _toggle.isOn;
    }
    public void changeMode()
    {
        _postVHSPro.enabled = _toggle.isOn;
        PlayerPrefs.SetInt("isRetroMode", Convert.ToInt32(_toggle.isOn));
    }
}
