using System.Collections;
using UnityEngine;


public class EnemyBehaviourSimple : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private SoundsPlayer _firePlayer;

    private float _enemySpeed = 2.0f;
    private float _evasionBorder = 2.0f;
    private float _fireRate = 1f;
    private float _randomizationCooldown = 3.0f;

    private string _soundName = "выстрел";
    private float _fireVolume = 0.5f;

    private Transform _playerTransform;
    private SimpleEnemyBulletSpawner _bulletSpawner;

    private bool _cooldown = false;
    private float _targetAngleLimit = 25f;

    private Vector3 _targetDir;
    private Vector3 _forward;
    private float _angle;

    private void OnEnable()
    {
        _cooldown = false;
    }
    private void Start()
    {
        _bulletSpawner = FindObjectOfType<SimpleEnemyBulletSpawner>();
        _playerTransform = FindObjectOfType<Player>().transform;
        StartCoroutine(RandomizeEnemy());
    }
    private IEnumerator RandomizeEnemy()
    {
        while (true)
        {
            _enemySpeed = Random.Range(0.7f, 1.4f);
            _evasionBorder = Random.Range(3f, 4.5f);
            _fireRate = Random.Range(1f, 3f);
            yield return new WaitForSeconds(_randomizationCooldown);
        }
    }
    private void Update()
    {
        float offset = transform.position.x - _playerTransform.position.x;
        if ((offset > 0) && (offset < _evasionBorder))
        {
            transform.Translate(_enemySpeed * Time.deltaTime * Vector3.right);
        }
        else if ((offset < 0) && (-offset < _evasionBorder))
        {
            transform.Translate(_enemySpeed * Time.deltaTime * Vector3.left);
        }
        else if (offset > 0)
        {
            transform.Translate(_enemySpeed * Time.deltaTime * Vector3.left);
        }
        else //if (offset < 0)
        {
            transform.Translate(_enemySpeed * Time.deltaTime * Vector3.right);
        }

        _targetDir = _playerTransform.position - transform.position;
        _forward = -transform.up;
        _angle = Vector3.SignedAngle(_targetDir, _forward, Vector3.forward);

        if (Mathf.Abs(_angle) < _targetAngleLimit)
        {
            TryShoot(_angle);
        }
    }

    public void TryShoot(float angle)
    {
        if (!_cooldown)
        {
            _firePlayer.Play(_soundName, _fireVolume);
            StartCoroutine(FireCooldown(_fireRate));
            _bulletSpawner.SpawnBullet(_firePoint.position, angle);
        }
    }

    private IEnumerator FireCooldown(float fireRate)
    {
        _cooldown = true;
        yield return new WaitForSeconds(fireRate);
        _cooldown = false;
    }
}