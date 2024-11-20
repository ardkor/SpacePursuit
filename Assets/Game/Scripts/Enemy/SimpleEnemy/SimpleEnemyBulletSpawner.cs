using UnityEngine;

public class SimpleEnemyBulletSpawner : ObjectPool
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject[] _bulletTemplates;

    private SimpleEnemyBullet _currentBullet;

    private void Start()
    {
        Initialize(_bulletTemplates);
    }
    public void SpawnBullet(Vector3 spawnPoint, float angle)
    {
        if (TryGetObject(out GameObject bullet))
        {
            bullet.SetActive(true);
            bullet.transform.position = spawnPoint;
            _currentBullet = bullet.GetComponent<SimpleEnemyBullet>();
            _currentBullet.SetRotation(new Vector2 (_playerTransform.position.x, _playerTransform.position.y), angle);
        }
    }
}
