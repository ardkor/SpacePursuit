using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyBullet : Bullet
{
    private Vector2 _direction;
    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime, Space.World);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.ApplyDamage(_damage);
        }

        Die();
    }
    public void SetRotation(Vector2 targetPosition, float angle, Vector3 direction)
    {
        

        //_direction = (targetPosition - position).normalized;
        //_direction = direction.normalized;
        //float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;

        Vector2 position = new Vector2(transform.position.x, transform.position.y);
        transform.rotation = Quaternion.AngleAxis(-180-angle, Vector3.forward);
        /*Quaternion rotationV = Quaternion.AngleAxis(-180 - angle, Vector3.forward);

        Vector2 newDirection = rotationV * direction;
        _direction = newDirection.normalized;*/

        Vector2 targetDir =targetPosition -position;
        _direction = targetDir.normalized;
    }
}
