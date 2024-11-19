using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class EnemyBehaviourLaser : MonoBehaviour
{
    private Transform _playerTransform;
    [SerializeField] private float _enemySpeed = 1.0f;
    [SerializeField] private float fireRate = 7.0f;
    [SerializeField] private float stopRate = 4.0f;
    private float fireRateSpeed = 0.3f;
    private float fireRateTimer = 0f;

    [SerializeField] private Transform _firePoint;
    private Coroutine fireCoroutine;
    private float stopTimer;
    private float fireTimer;
    // Start is called before the first frame update
    private LaserEnemyBulletSpawner laserEnemyBulletSpawner;
    private LaserPlayer _firePlayer;
    private string _soundName = "очередь";
    private bool _wasSound = false;
    void Start()
    {
        _firePlayer = FindObjectOfType<LaserPlayer>();
        laserEnemyBulletSpawner = FindObjectOfType<LaserEnemyBulletSpawner>();
        _playerTransform = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;
        stopTimer += Time.deltaTime;
        fireRateTimer += Time.deltaTime;
        if (transform.position.x < _playerTransform.position.x)
        {
            transform.Translate(Vector3.right * _enemySpeed * Time.deltaTime);
        }
        else if (transform.position.x > _playerTransform.position.x)
        {
            transform.Translate(Vector3.left * _enemySpeed * Time.deltaTime);
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
                _firePlayer.PlayVolumed(_soundName, 0.05f);
                _wasSound = true;
            }
                /*if (fireCoroutine == null)
                {
                    fireCoroutine = StartCoroutine(LineFire());
                }*/
                if (fireTimer >= fireRate) 
                {
                _wasSound = false;
                 // StopCoroutine(fireCoroutine);
                 fireTimer = 0.0f;
                stopTimer = 0.0f;
                _enemySpeed = 1.0f;
            }
        

        }
    }

    IEnumerator LineFire()
    {
        laserEnemyBulletSpawner.SpawnBullet(_firePoint.position);

        yield return new WaitForSeconds(fireRateSpeed);
    }
}
