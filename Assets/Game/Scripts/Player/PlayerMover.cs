using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerEnergy))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    [SerializeField] private float _maxHeight;
    [SerializeField] private float _minHeight;
    [SerializeField] private float _minLeft;
    [SerializeField] private float _maxRight;

    [SerializeField] private float _moveEnergySpend;
    [SerializeField] private float _fadeSpeed;
    [SerializeField] private SpriteRenderer _engineSprite;
    [SerializeField] private SoundsPlayer _soundsPlayer;
    [SerializeField] private float _volume = 0.15f;
    private string _soundName = "двигатель";
    private PlayerEnergy _playerEnergy;
    private float alpha;
    private float prevPosX = 0f;
    private void Start()
    {
        _playerEnergy = GetComponent<PlayerEnergy>();
        alpha = _engineSprite.color.a;
        _soundsPlayer.PlayVolumedLoop(_soundName, _volume);
        _soundsPlayer.TryPause();
    }
    private void Update()
    {
        alpha -= _fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);
        _engineSprite.color = new Color(_engineSprite.color.r, _engineSprite.color.g, _engineSprite.color.b, alpha);
        if (prevPosX == transform.position.x)
        {
            if (_soundsPlayer.isPlaying())
            {
               // Debug.Log("fade");
                _soundsPlayer.FadeSound();
            }
        }
        prevPosX = transform.position.x;
    }
    public void TryMove(float moveInput)
    {
        //_engineSprite.color = new Color(_engineSprite.color.r, _engineSprite.color.g, _engineSprite.color.b, alpha);
        if (_playerEnergy.trySpendEnergy(_moveEnergySpend * Time.deltaTime))
        {
            if (!_soundsPlayer.isPlaying())
            {
                
                _soundsPlayer.IncreaseSound();
            }
            alpha += _fadeSpeed * Time.deltaTime * 2;
            alpha = Mathf.Clamp01(alpha);
            Vector3 movement = Vector3.right * moveInput * _moveSpeed * Time.deltaTime;

            float newXPos = Mathf.Clamp(transform.position.x + movement.x, _minLeft, _maxRight);
            transform.position = new Vector3(newXPos, transform.position.y, transform.position.z);
        }
    }
}




