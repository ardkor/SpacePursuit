using System.Collections;
using UnityEngine;

public class EnemyBehaviourRocket : MonoBehaviour
{
    [SerializeField] private float _enemySpeed = 1.5f;
    [SerializeField] private EnemyMover _enemyMover;

    [SerializeField] private Transform _firePoint;
    [SerializeField] private SoundsPlayer _firePlayer;

    private float _randomisationCooldown = 3.0f;
    private float _fireRate = 1f;

    private string _soundName = "выстрел";
    private float _fireVolume = 0.5f;

    private RocketEnemyBulletSpawner _bulletSpawner;

    private float _leftTpPos = -14.5f;
    private float _rightTpPos = 14.5f;

    private float _leftBorder = -15f;
    private float _rightBorder = 15f;
    private float _yDisplacementTimer;

    private float _cooldownTime = 2f;

    private bool _randomShoot;
    private bool _randomDirection;
    private bool _upDown = true;
    private bool _cooldown = false;

    private Vector3 _positionChanger;

    private void OnEnable()
    {
        _cooldown = false;
    }

    private void Start()
    {
        _bulletSpawner = FindObjectOfType<RocketEnemyBulletSpawner>();
        _enemyMover = GetComponent<EnemyMover>();
        StartCoroutine(RandomizeEnemy());
    }

    private void Update()
    {
        _enemyMover.TryStop();
        _yDisplacementTimer += Time.deltaTime;

        if (_upDown) { 
            transform.Translate(0.7f * Time.deltaTime * Vector3.down);
        }
        else{
            transform.Translate(0.7f * Time.deltaTime * Vector3.up);
        }

        if (_yDisplacementTimer >= 2)
        {
            if (_upDown) { _upDown = false; } 
            else { _upDown = true; }
            _yDisplacementTimer = 0;
        }

        if (_randomDirection)
        {
            transform.Translate(_enemySpeed * Time.deltaTime * Vector3.right);
        }
        else
        {
            transform.Translate(_enemySpeed * Time.deltaTime * Vector3.left);
        }

        if (transform.position.x > _rightBorder)
        {
            _positionChanger = transform.position;
            _positionChanger.x = _leftTpPos;
            transform.position = _positionChanger;
        }
        else if (transform.position.x < _leftBorder)
        {
            _positionChanger = transform.position;
            _positionChanger.x = _rightTpPos;
            transform.position = _positionChanger;
        }

        if(_randomShoot)
        {
            if (!_cooldown)
            {
                _bulletSpawner.SpawnBullet(_firePoint.position);
                StartCoroutine(FireCooldown());
            }
        }
    }

    private IEnumerator RandomizeEnemy()
    {
        while (true)
        {
            _enemySpeed = Random.Range(1f, 2f);
            //randomMove = UnityEngine.Random.Range(0,2) == 1;
            _randomShoot = Random.Range(0, 2) == 1;
            _randomDirection = Random.Range(0, 2) == 1;
            _cooldownTime = Random.Range(3f, 5f);

            yield return new WaitForSeconds(2);
        }
    }
    private IEnumerator FireCooldown()
    {
        _cooldown = true;
        yield return new WaitForSeconds(_cooldownTime);
        _cooldown = false;
    }
}
