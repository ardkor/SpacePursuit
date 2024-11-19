using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private AudioListener _camerListener;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Player _player;

    private CanvasGroup _gameOverGroup;

    private void OnEnable()
    {
        _player.Died += OnDied;
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }
    private void OnDisable()
    {
        _player.Died -= OnDied;
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }
    private void Start()
    {
        _gameOverGroup = GetComponent<CanvasGroup>();
        _gameOverGroup.alpha = 0;
        _gameOverGroup.blocksRaycasts = false;
        _restartButton.interactable = false;
        _exitButton.interactable = false;
    }

    private void OnDied()
    {
        _camerListener.enabled = true;
        _gameScreen.SetActive(false);
        _gameOverGroup.blocksRaycasts = true;
        _restartButton.interactable = true;
        _exitButton.interactable = true;
        _gameOverGroup.alpha = 1;
        Time.timeScale = 0;
    }

    private void OnRestartButtonClick()
    {
        _gameOverGroup.blocksRaycasts = false;
        _restartButton.interactable = false;
        _exitButton.interactable = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}
