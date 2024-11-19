using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerEnergy))]
public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private float _fireRate;
    [SerializeField] private float _fireEnergySpend;
    [SerializeField] private float _fireVolume = 0.6f;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private SoundsPlayer _soundsPlayer;
    private string _soundName = "выстрел";
    private Coroutine cooldownCoroutine;
    private bool cooldown = false;
    private PlayerEnergy _playerEnergy;
    private void Start()
    {
        _playerEnergy = GetComponent<PlayerEnergy>();
    }

    public void TryShoot()
    {
        if (!cooldown)
        {
            if (_playerEnergy.trySpendEnergy(_fireEnergySpend))
            {
                _soundsPlayer.Play(_soundName, _fireVolume);
                cooldown = true;
                cooldownCoroutine = StartCoroutine(FireCooldown(_fireRate));
                _bulletSpawner.SpawnBullet(_firePoint.position);
            }
        }
    }

    private IEnumerator FireCooldown(float fireRate)
    {
        yield return new WaitForSeconds(fireRate);
        cooldown = false;
    }
    
}
