using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private int _health;
    [SerializeField] private int _scoreNumber;
    private Score _score;
    ExplosionPlayersSpawner explosionPlayersPool;
    private void Start()
    {
        explosionPlayersPool = FindObjectOfType<ExplosionPlayersSpawner>();
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
        explosionPlayersPool.TrySpawnExplosionPlayer(transform.position);
        _score.AddScore(_scoreNumber);
        gameObject.SetActive(false);
    }
}
