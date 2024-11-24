using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearEnemyBulletSpawner : ObjectPool
{
    [SerializeField] private GameObject[] _bulletTemplates;

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
        }
    }
}
