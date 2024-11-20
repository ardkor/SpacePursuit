using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _bestScoreText;
    [SerializeField] private TMP_Text _lastScoreText;
    [SerializeField] private Player _player;

    private int _score;
    private int _bestScore;
    private int _lastScore;
    
    private void Start()
    {
        _bestScore = PlayerPrefs.GetInt("BestScore", 0);
        _lastScore = PlayerPrefs.GetInt("LastScore", 0);
        _bestScoreText.text = _bestScore.ToString();
        _lastScoreText.text = _lastScore.ToString();
        _score = 0;
        _scoreText.text = _score.ToString();
    }
    private void OnEnable()
    {
        _player.Died += OnDied;
    }
    private void OnDisable()
    {
        _player.Died -= OnDied;
    }
    public void AddScore(int amount)
    {
        _score += amount;
        UpdateScore();
    }
    private void UpdateScore()
    {
        _scoreText.text = _score.ToString();
    }
    private void UpdateBestScore()
    {
        _bestScore = _score;
        _bestScoreText.text = _bestScore.ToString();
        PlayerPrefs.SetInt("BestScore", _bestScore);
    }
    private void UpdateLastScore()
    {
        _lastScore = _score;
        _lastScoreText.text = _lastScore.ToString();
        PlayerPrefs.SetInt("LastScore", _lastScore);
    }
    private void OnDied()
    {
        UpdateLastScore();
        if (_score > _bestScore) 
        {
            UpdateBestScore();
        }
    }
}
