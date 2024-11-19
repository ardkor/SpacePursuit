using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBehaviourSimple : MonoBehaviour
{
    [SerializeField] private float _enemySpeed = 2.0f;
    [SerializeField] private float _Offset = 2.0f;
    [SerializeField] private float _randCd = 3.0f;

    [SerializeField] private float _fireRate = 1f;
    [SerializeField] private Transform _firePoint;

    private Transform _playerTransform;
    private SimpleEnemyBulletSpawner _bulletSpawner;
    private Coroutine cooldownCoroutine;

    private bool cooldown = false;
    float targetAngleLimit = 30f;

    void Start()
    {
        _bulletSpawner = FindObjectOfType<SimpleEnemyBulletSpawner>();
        _playerTransform = FindObjectOfType<Player>().transform;
        StartCoroutine(RandomizeEnemy());
    }
    IEnumerator RandomizeEnemy()
    {
        while (true)
        {
            _Offset = UnityEngine.Random.Range(0f, 3.5f);

            yield return new WaitForSeconds(_randCd);
        }
    }
    // Update is called once per frame
    void Update()
    {

        if ((transform.position.x < _playerTransform.position.x) && (transform.position.x > (_playerTransform.position.x - _Offset)))
        {
            transform.Translate(Vector3.left * _enemySpeed * Time.deltaTime);
        }
        else if ((transform.position.x > _playerTransform.position.x) && (transform.position.x < (_playerTransform.position.x + _Offset)))
        {
            transform.Translate(Vector3.right * _enemySpeed * Time.deltaTime);
        }
        else if (transform.position.x < _playerTransform.position.x)
        {
            transform.Translate(Vector3.right * _enemySpeed * Time.deltaTime);
        }
        else if (transform.position.x > _playerTransform.position.x)
        {
            transform.Translate(Vector3.left * _enemySpeed * Time.deltaTime);
        }

        //shoot
        Vector3 targetDir = _playerTransform.position - transform.position;
        Vector3 forward = -transform.up;
        float angle = Vector3.SignedAngle(targetDir, forward, Vector3.forward);
        /*        Vector3 forward = -transform.up;
                float angle = Vector3.SignedAngle(targetDir, forward, Vector3.up);*/
        //float angle = Vector3.SignedAngle(transform.forward, _playerTransform.position - transform.position, Vector3.down);
        
        // ѕровер€ем, меньше ли угол заданного предела
        if (Mathf.Abs(angle) < targetAngleLimit)
        {
            TryShoot(angle, targetDir);
        }
    }

    public void TryShoot(float angle, Vector3 targetDir)
    {
        if (!cooldown)
        {
            Debug.Log(angle);
            cooldown = true;
            cooldownCoroutine = StartCoroutine(FireCooldown(_fireRate));
            _bulletSpawner.SpawnBullet(_firePoint.position, angle, targetDir);
        }
    }

    private IEnumerator FireCooldown(float fireRate)
    {
        yield return new WaitForSeconds(fireRate);
        cooldown = false;
    }
}