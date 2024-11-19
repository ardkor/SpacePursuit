using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    private int _score;
    void Start()
    {
        _score = 0;
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
}
