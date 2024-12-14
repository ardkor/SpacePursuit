using UnityEngine;
using System.Collections;
public class EnemyBehaviourLinear : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private SoundsPlayer _firePlayer;

    private Transform _playerTransform;

    private float _enemySpeed = 3.0f;
    private float _targetSpeed = 1.0f;
    private float _fireVolume = 0.5f;

    private float _stopRate = 6.0f;
    private float _stopTimer = 0f;

    private float _fireTime = 0.4f;
    private float _fireTimer = 0f;

    private float _fireRate = 0.07f;
    private float _fireRateTimer = 0f;
    private float _evasionBorder = 0.02f;
    private float _randomizationCooldown = 3.0f;

    private LinearEnemyBulletSpawner _linearEnemyBulletSpawner;
    private string _soundName = "очередь";
    private bool _wasSound = false;

    private void Start()
    {
        _linearEnemyBulletSpawner = FindObjectOfType<LinearEnemyBulletSpawner>();
        _playerTransform = FindObjectOfType<Player>().transform;
        //_targetSpeed = Random.Range(1.5f, 3f);
        StartCoroutine(RandomizeEnemy());
    }
    
    private IEnumerator RandomizeEnemy()
    {
        while (true)
        {
            _enemySpeed = Random.Range(1.5f, 3f);
            //_evasionBorder = Random.Range(3f, 4.5f);
            _fireRate = Random.Range(0.07f, 0.1f);
            yield return new WaitForSeconds(_randomizationCooldown);
        }
    }
    private void Update()
    {
        _stopTimer += Time.deltaTime;
        float offset = transform.position.x - _playerTransform.position.x;
        if ((offset > 0) && (offset < Time.deltaTime + 0.01f))
        {
            _stopTimer += Time.deltaTime;
        }
        else if ((offset < 0) && (-offset < Time.deltaTime + 0.01f))
        {
            _stopTimer += Time.deltaTime;
        }
        else if (offset > 0)
        {
            transform.Translate(_enemySpeed * Time.deltaTime * Vector3.left);
        }
        else if (offset < 0)
        {
            transform.Translate(_enemySpeed * Time.deltaTime * Vector3.right);
        }
        /*if (transform.position.x - _playerTransform.position.x < 0.01)
        {
            transform.Translate(_enemySpeed * Time.deltaTime * Vector3.right);
        }
        else if (transform.position.x - _playerTransform.position.x > 0.01)
        {
            transform.Translate(_enemySpeed * Time.deltaTime * Vector3.left);
        }
        else if (transform.position.x - _playerTransform.position.x < 0.01f)
        {
            _stopTimer = _stopRate;
        }*/

        if (_stopTimer >= _stopRate)
        {
            _fireRateTimer += Time.deltaTime;
            _fireTimer += Time.deltaTime;
            _enemySpeed = 0.0f;
            if (_fireRateTimer >= _fireRate) {
                _linearEnemyBulletSpawner.SpawnBullet(_firePoint.position);
                _fireRateTimer = 0f;
            }
            if (!_wasSound)
            {
                _firePlayer.Play(_soundName, _fireVolume);
                _wasSound = true;
            }
            if (_fireTimer >= _fireTime) 
            {
                _wasSound = false;
                _fireTimer = 0.0f;
                _stopTimer = 0.0f;
               // _enemySpeed = _targetSpeed;
            }
        }
    }
}
