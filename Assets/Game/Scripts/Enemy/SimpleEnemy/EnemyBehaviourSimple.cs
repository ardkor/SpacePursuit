using System.Collections;
using UnityEngine;


public class EnemyBehaviourSimple : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private SoundsPlayer _firePlayer;

    private float _enemySpeed = 2.0f;
    private float _EvasionBorder = 2.0f;
    private float _randCd = 3.0f;
    private float _fireRate = 1f;

    private string _soundName = "выстрел";
    private float _fireVolume = 0.5f;

    private Transform _playerTransform;
    private SimpleEnemyBulletSpawner _bulletSpawner;

    private bool cooldown = false;
    float targetAngleLimit = 30f;

    Vector3 targetDir;
    Vector3 forward;
    float angle;

    private void OnEnable()
    {
        cooldown = false;
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
            _EvasionBorder = UnityEngine.Random.Range(0f, 3.5f);

            yield return new WaitForSeconds(_randCd);
        }
    }
    private void Update()
    {
        float offset = transform.position.x - _playerTransform.position.x;
        if ((offset > 0) && ((offset - _EvasionBorder) < 0))
        {
            transform.Translate(_enemySpeed * Time.deltaTime * Vector3.right);
        }
        else if ((offset < 0) && ((offset + _EvasionBorder) > 0))
        {
            transform.Translate(_enemySpeed * Time.deltaTime * Vector3.left);
        }
        else if (offset > 0)
        {
            transform.Translate(_enemySpeed * Time.deltaTime * Vector3.left);
        }
        else if (offset < 0)
        {
            transform.Translate(_enemySpeed * Time.deltaTime * Vector3.right);
        }

        targetDir = _playerTransform.position - transform.position;
        forward = -transform.up;
        angle = Vector3.SignedAngle(targetDir, forward, Vector3.forward);

        if (Mathf.Abs(angle) < targetAngleLimit)
        {
            TryShoot(angle);
        }
    }

    public void TryShoot(float angle)
    {
        if (!cooldown)
        {
            _firePlayer.Play(_soundName, _fireVolume);
            cooldown = true;
            StartCoroutine(FireCooldown(_fireRate));
            _bulletSpawner.SpawnBullet(_firePoint.position, angle);
        }
    }

    private IEnumerator FireCooldown(float fireRate)
    {
        yield return new WaitForSeconds(fireRate);
        cooldown = false;
    }
}