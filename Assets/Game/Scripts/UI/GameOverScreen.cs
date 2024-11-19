using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button _restarButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Player _player;

    private CanvasGroup _gameOverGroup;

    private void OnEnable()
    {
        _player.Died += OnDied;
        _restarButton.onClick.AddListener(OnRestartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }
    private void OnDisable()
    {
        _player.Died -= OnDied;
        _restarButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }
    private void Start()
    {
        _gameOverGroup = GetComponent<CanvasGroup>();
        _gameOverGroup.alpha = 0;
        _restarButton.interactable = false;
        _exitButton.interactable = false;
    }

    private void OnDied()
    {
        _restarButton.interactable = true;
        _exitButton.interactable = true;
        _gameOverGroup.alpha = 1;
        Time.timeScale = 0;
    }

    private void OnRestartButtonClick()
    {
        _restarButton.interactable = false;
        _exitButton.interactable = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}
