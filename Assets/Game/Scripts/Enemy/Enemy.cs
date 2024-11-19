using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private int _health;
    [SerializeField] private int _scoreNumber;
    private Score _score;
    [SerializeField] private BoomPlayer _boomPlayer;
    private string _soundName = "взрыв";
    private void Start()
    {
        _boomPlayer = FindAnyObjectByType<BoomPlayer>();
        _score = FindAnyObjectByType<Score>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.ApplyDamage(_damage);
        }
        Die();
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
            Die();
    }
    private void Die()
    {
        _boomPlayer.Play(_soundName);
        _score.AddScore(_scoreNumber);
        gameObject.SetActive(false);
    }
}
