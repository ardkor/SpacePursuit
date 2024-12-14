using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerShooter))]

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerShooter _shooter;
    [SerializeField] private FixedJoystick _fixedJoystick;
    private float moveInput;
    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
        _shooter = GetComponent<PlayerShooter>();
    }

    private void Update()
    {
        //mobile input
        moveInput = _fixedJoystick.Horizontal;
        if (moveInput != 0)
        {
            _mover.TryMove(moveInput);
        }
        /*if (Input.GetKey(KeyCode.Mouse0))
        {
            _shooter.TryShoot();
        }*/
        // pc input
        /*if (Input.GetAxisRaw("Horizontal") != 0)
        {
            float moveInput = Input.GetAxisRaw("Horizontal");
            _mover.TryMove(moveInput);
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            _shooter.TryShoot();
        }*/
    }
    public void ShootButton()
    {
        _shooter.TryShoot();
    }
}
