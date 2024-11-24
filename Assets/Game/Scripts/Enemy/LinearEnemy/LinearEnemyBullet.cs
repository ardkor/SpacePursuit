using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearEnemyBullet : Bullet
{
    private void Update()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.ApplyDamage(_damage);
        }

        Die();
    }
}
