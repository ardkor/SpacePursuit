using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScreen : MonoBehaviour
{
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private AudioListener _camerListener;
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _exitGameButton;
    [SerializeField] private Button _pauseButton;

    private CanvasGroup _gameOverGroup;
    private void OnEnable()
    {
        _pauseButton.onClick.AddListener(OnPauseButtonClick);
        _exitGameButton.onClick.AddListener(OnExitGameButtonClick);
        _playButton.onClick.AddListener(OnStartGameButtonClick);
    }
    private void OnDisable()
    {
        _pauseButton.onClick.RemoveListener(OnPauseButtonClick);
        _exitGameButton.onClick.RemoveListener(OnExitGameButtonClick);
        _playButton.onClick.RemoveListener(OnStartGameButtonClick);
        _playButton.onClick.RemoveListener(OnBackToGameButtonClick);
    }
    private void Start()
    {
        _camerListener.enabled = true;
        _gameOverGroup = GetComponent<CanvasGroup>();
        _gameOverGroup.alpha = 1;
        _gameOverGroup.blocksRaycasts = true;
        _exitGameButton.interactable = true;
        _playButton.interactable = true;
    }
    private void OnBackToGameButtonClick()
    {
        Time.timeScale = 1;
        _gameOverGroup.blocksRaycasts = false;
        _gameOverGroup.alpha = 0;
        _exitGameButton.interactable = false;
        _playButton.interactable = false;
    }
    private void OnStartGameButtonClick()
    {
        _camerListener.enabled = false;
        OnBackToGameButtonClick();
        _gameScreen.SetActive(true);
        _playButton.onClick.RemoveListener(OnStartGameButtonClick);
        _playButton.onClick.AddListener(OnBackToGameButtonClick);
    }
    private void OnPauseButtonClick()
    {
        Time.timeScale = 0;
        _gameOverGroup.blocksRaycasts = true;
        _gameOverGroup.alpha = 1;
        _exitGameButton.interactable = true;
        _playButton.interactable = true;
    }
    
    private void OnExitGameButtonClick()
    {
        Application.Quit();
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
