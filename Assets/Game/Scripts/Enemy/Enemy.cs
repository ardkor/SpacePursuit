using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private int _health;
    [SerializeField] private int _scoreNumber;

    private Score _score;
    private ExplosionPlayersSpawner _explosionPlayersSpawner;
    private ExplosionSpritesSpawner _explosionSpritesSpawner;
    private void Start()
    {
        _explosionSpritesSpawner = FindObjectOfType<ExplosionSpritesSpawner>();
        _explosionPlayersSpawner = FindObjectOfType<ExplosionPlayersSpawner>();
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
        _explosionPlayersSpawner.TrySpawnExplosionPlayer(transform.position);
        _explosionSpritesSpawner.TrySpawnExplosionSprite(transform.position);
        _score.AddScore(_scoreNumber);
        gameObject.SetActive(false);
    }
}
