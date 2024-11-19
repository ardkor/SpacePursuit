using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionPlayersSpawner : ObjectPool
{
    [SerializeField] private GameObject _explosionPlayersTemplate;
     //private List<GameObject> _explosionPlayers;
    //private List<SoundsPlayer> soundsPlayers;
    private float _pitch;
    private float _volume = 1f;
    private SoundsPlayer _currentPlayer;
    private string _soundName = "взрыв";
    private void Start()
    {
        //_explosionPlayers = new List<GameObject>();
        Initialize(_explosionPlayersTemplate);
    }
    private void Update()
    {
        foreach (GameObject _explosionPlayer in _pool)
        {
            if (!_explosionPlayer.GetComponentInChildren<AudioSource>())
            {
                _explosionPlayer.SetActive(false);
            }
        }
    }
    public void TrySpawnExplosionPlayer(Vector3 position)
    {
        if (TryGetObject(out GameObject explosionPlayer))
        {
            _pitch = Random.Range(0.9f, 1f);
            explosionPlayer.SetActive(true);
            explosionPlayer.transform.position = position;
            _currentPlayer = explosionPlayer.GetComponent<SoundsPlayer>();
            _currentPlayer.Play(_soundName, _volume, _pitch);
        }
    }
}
