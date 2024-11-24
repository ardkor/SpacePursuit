using UnityEngine;
using System.Collections;

public class EnemySpawner : ObjectPool
{
    [SerializeField] private GameObject[] _enemyTemplates;
    [SerializeField] private Transform[] _spawnPoints;
    private float _secondsBetweenSpawn;

    private float _arriveVolume = 1f;
    private float _arrivePitch = 1f;
    private float _soundDistance = 30f;
    private SoundsPlayer _arrivePlayer;
    private string _soundName = "прибытие";
    private float _elapsedTime = 0;
    private float _randomisationCooldown = 3.0f;

    private void Start()
    {
        Initialize(_enemyTemplates);
        StartCoroutine(RandomizeSpawner());
    }
    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondsBetweenSpawn)
        {
            if (TryGetObject(out GameObject enemy))
            {
                _elapsedTime = 0;

                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
                SetEnemy(enemy, _spawnPoints[spawnPointNumber]);
            }
        }
    }

    private void SetEnemy(GameObject enemy, Transform spawnPoint)
    {
        _arrivePlayer = spawnPoint.GetComponent<SoundsPlayer>();
        _arrivePlayer.Play(_soundName, _arriveVolume, _arrivePitch, _soundDistance);
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint.position;
    }
    private IEnumerator RandomizeSpawner()
    {
        while (true)
        {
            _secondsBetweenSpawn = Random.Range(2f, 4f);
            _randomisationCooldown = _secondsBetweenSpawn;
            yield return new WaitForSeconds(_randomisationCooldown);
        }
    }
}
