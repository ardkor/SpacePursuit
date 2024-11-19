using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerShooter))]

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerShooter _shooter;

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
        _shooter = GetComponent<PlayerShooter>();
    }

    private void Update()
    {

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            float moveInput = Input.GetAxisRaw("Horizontal");
            _mover.TryMove(moveInput);
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            _shooter.TryShoot();
        }
    }
}
