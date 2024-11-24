using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketEnemyBulletSpawner : ObjectPool
{
    [SerializeField] private GameObject[] _bulletTemplates;
    [SerializeField] private Transform _playerTransform;

    private RocketEnemyBullet _rocketEnemyBullet;

    private void Start()
    {
        Initialize(_bulletTemplates);
    }
    public void SpawnBullet(Vector3 spawnPoint)
    {
        if (TryGetObject(out GameObject bullet))
        {
            bullet.SetActive(true);
            bullet.transform.position = spawnPoint;
            _rocketEnemyBullet = bullet.GetComponent<RocketEnemyBullet>();
            _rocketEnemyBullet.Initialise(_playerTransform);
        }
    }
}
