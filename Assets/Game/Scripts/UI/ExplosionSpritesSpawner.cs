/*
using System.Collections.Generic;*/
using System.Collections;
using UnityEngine;

public class ExplosionSpritesSpawner : ObjectPool
{
    [SerializeField] private GameObject _explosionSpriteTemplate;

    private float _animationTime = 0.59f;

    private void Start()
    {
        Initialize(_explosionSpriteTemplate);
    }
    public void TrySpawnExplosionSprite(Vector3 position)
    {
        if (TryGetObject(out GameObject explosionSprite))
        {
            explosionSprite.SetActive(true);
            explosionSprite.transform.position = position;
            StartCoroutine(ExplosionTimer(explosionSprite));
        }
    }
    private IEnumerator ExplosionTimer(GameObject explosionSprite)
    {
        yield return new WaitForSeconds(_animationTime);
        explosionSprite.SetActive(false);
    }
}
