using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketEnemyBullet : Bullet
{
    private Transform _target;
    private bool _clockwise = true;

    private Vector3 _startPosition;
    private Vector3 _targetDirection;
    private float _targetAngle;

    private RocketExplosionSpritesSpawner _rocketExplosionSpritesSpawner;

    public void Initialise(Transform target)
    {
        _target = target;
        _startPosition = transform.position;
        _targetDirection = (_target.position - _startPosition).normalized;
        _targetAngle = _clockwise ? Vector3.Angle(_targetDirection, Vector3.up) : 360f - Vector3.Angle(_targetDirection, Vector3.up);
    }

    private void Update()
    {
        float angle = (transform.position - _startPosition).magnitude * _speed / _targetAngle;

        if (_clockwise)
        {
            transform.position = _startPosition + Quaternion.AngleAxis(angle, Vector3.forward) * _targetDirection;
        }
        else
        {
            transform.position = _startPosition + Quaternion.AngleAxis(angle, Vector3.back) * _targetDirection;
        }

        if ((transform.position - _target.position).magnitude < 0.1f)
        {
            transform.position = _target.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.ApplyDamage(_damage);
        }
        _rocketExplosionSpritesSpawner.TrySpawnExplosionSprite(transform.position);
        Die();
    }
}
