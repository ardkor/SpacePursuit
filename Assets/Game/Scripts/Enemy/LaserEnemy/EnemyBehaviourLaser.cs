using UnityEngine;

public class EnemyBehaviourLaser : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private SoundsPlayer _firePlayer;

    private Transform _playerTransform;
    private float _enemySpeed = 1.0f;
    private float fireRate = 7.0f;
    private float stopRate = 4.0f;
    private float _fireVolume = 0.5f;
    private float fireRateSpeed = 0.3f;
    private float fireRateTimer = 0f;
    private float stopTimer;
    private float fireTimer;

    private LaserEnemyBulletSpawner laserEnemyBulletSpawner;
    private string _soundName = "очередь";
    private bool _wasSound = false;

    private void Start()
    {
        laserEnemyBulletSpawner = FindObjectOfType<LaserEnemyBulletSpawner>();
        _playerTransform = FindObjectOfType<Player>().transform;
    }

    private void Update()
    {
        fireTimer += Time.deltaTime;
        stopTimer += Time.deltaTime;
        fireRateTimer += Time.deltaTime;
        if (transform.position.x < _playerTransform.position.x)
        {
            transform.Translate(_enemySpeed * Time.deltaTime * Vector3.right);
        }
        else if (transform.position.x > _playerTransform.position.x)
        {
            transform.Translate(_enemySpeed * Time.deltaTime * Vector3.left);
        }

        if (stopTimer >= stopRate)
        {
            _enemySpeed = 0.0f;
            if (fireRateTimer >= fireRateSpeed) {
                laserEnemyBulletSpawner.SpawnBullet(_firePoint.position);
                fireRateTimer = 0f;
            }
            if (!_wasSound)
            {
                _firePlayer.Play(_soundName, _fireVolume);
                _wasSound = true;
            }
                if (fireTimer >= fireRate) 
                {
                _wasSound = false;
                 fireTimer = 0.0f;
                stopTimer = 0.0f;
                _enemySpeed = 1.0f;
            }
        

        }
    }
}
