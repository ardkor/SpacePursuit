using UnityEngine;

public class SimpleEnemyBullet : Bullet
{
    private Vector2 _direction;

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * _direction, Space.World);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.ApplyDamage(_damage);
        }

        Die();
    }
    public void SetRotation(Vector2 targetPosition, float angle)
    {
        transform.rotation = Quaternion.AngleAxis(-180-angle, Vector3.forward);
        Vector2 position = new Vector2(transform.position.x, transform.position.y);

        Vector2 targetDir = targetPosition - position;
        _direction = targetDir.normalized;
    }
}
