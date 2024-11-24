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
    private void Start()
    {
        _rocketExplosionSpritesSpawner = FindAnyObjectByType<RocketExplosionSpritesSpawner>();
        _explosionPlayersSpawner = FindAnyObjectByType<ExplosionPlayersSpawner>();
    }
    /*    public void Initialise(Transform target)
        {
            _target = target;
            _startPosition = transform.position;
            _targetDirection = (_target.position - _startPosition).normalized;
            _targetAngle = _clockwise ? Vector3.Angle(_targetDirection, Vector3.up) : 360f - Vector3.Angle(_targetDirection, Vector3.up);
        }*/

    /*    [SerializeField]
        private float _moveSpeed;*/
    
    private float _startAngle = 90f;
    [SerializeField]
    private AnimationCurve _movementCurve;

    private float _angle;
    private float _rotationAngle;
    private float _yBorder = -3.19f;
   
    private Vector3 _targetPosition;
    private Vector3 _moveDirection;
    private Vector3 _startDirection;

    private float _time = 0f;

    private Vector3 _targetDir;
    private Vector3 _forward;
    private Vector3 point_0;
    private Vector3 point_1;
    private Vector3 point_2;
    private ExplosionPlayersSpawner _explosionPlayersSpawner;
    float count = 0.0f;

    private void OnEnable()
    {
        count = 0.0f;
    }
    public void Initialise(Transform target)
    {
        _targetPosition = target.position - (new Vector3(0f, 0.2f, 0f));
        _startDirection = _targetPosition - transform.position;
        //_angle = _startAngle;
       /* point_0 = transform.position;
        point_2 = _targetPosition;
        _targetDir = point_2 - point_0;
        if ((point_2.x - point_0.x) > 0)
        {
            point_1 = (point_2 - point_0) / 2 + Vector3.right * 2f + Vector3.up;  //point_0 + (point_2 - point_0) / 2 + Vector3.left * 2f;
        }
        else
        {
            point_1 = (point_2 - point_0) / 2 + Vector3.left * 2f + Vector3.up;  //- point_0 + (point_2 - point_0) / 2 + Vector3.right * 2f;
        }*/
        /* _targetDir = _targetPosition;
         _forward = -transform.up;
         _rotationAngle = Vector3.SignedAngle(_targetPosition, _forward, Vector3.forward);
         transform.rotation = Quaternion.AngleAxis(-180 - _rotationAngle, Vector3.forward);*/
    }
    // Assuming point_0 and point_2 are your starting point and destination
    // and all points are Vector3
    // Play with 5.0 to change the curve

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * _startDirection.normalized);
        /*if (count < 1.0f)
        {
            count += 1.0f * Time.deltaTime / Mathf.Abs(_targetDir.normalized.x);

            Vector3 m1 = Vector3.Lerp(point_0, point_1, count);
            Vector3 m2 = Vector3.Lerp(point_1, point_2, count);
            transform.position = Vector3.Lerp(m1, m2, count);
        }*/

        // _time += Time.deltaTime;
        // _angle = _startAngle * _movementCurve.Evaluate(_time);
        //Debug.Log(_angle * Mathf.Deg2Rad);
        //_moveDirection = new Vector2(-_startDirection.normalized.x * _movementCurve.Evaluate(_time), _startDirection.normalized.y);
        /*if (_startDirection.normalized.x > 0)
        {
            _moveDirection = new Vector2(_startDirection.normalized.x * _movementCurve.Evaluate(_time), _startDirection.normalized.y);
        }
        else
        {
            
        }*/
        //_startDirection.normalized / Mathf.Cos(_angle * Mathf.Deg2Rad);
        // transform.Translate(Time.deltaTime * _speed * _moveDirection);
        if (transform.position.y <= _yBorder)
        {
            _rocketExplosionSpritesSpawner.TrySpawnExplosionSprite(transform.position);
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.ApplyDamage(_damage);
        }
        _rocketExplosionSpritesSpawner.TrySpawnExplosionSprite(transform.position);
        _explosionPlayersSpawner.TrySpawnExplosionPlayer(transform.position);
        Die();
    }
}
