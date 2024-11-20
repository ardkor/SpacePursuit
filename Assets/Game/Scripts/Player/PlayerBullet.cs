using UnityEngine;

public class PlayerBullet : Bullet
{

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector2.down);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.ApplyDamage(_damage);
        }

        Die();
    }

}
