using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Stats")]
    [Tooltip("Controla la velocidad de movimiento del personaje")]
    [SerializeField]private float _playerSpeed = 5;
    [Tooltip("Controla la fueza de salto del personaje")]
    [SerializeField]private float _jumpForce = 5;
    private float _playerInputH;

    private Rigidbody2D _rBody2D;
    private GroundSensor _sensor;
    private Animator _animator;

    void Start()
    {
        _rBody2D = GetComponent<Rigidbody2D>();
        _sensor = GetComponentInChildren<GroundSensor>();
        _animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        PlayerMovement();

        if(Input.GetButtonDown("Jump") && _sensor._isGrounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
       _rBody2D.velocity = new Vector2(_playerInputH * _playerSpeed, _rBody2D.velocity.y);
    }

    void PlayerMovement()
    {
        _playerInputH = Input.GetAxis("Horizontal");

        if(_playerInputH != 0)
        {
            _animator.SetBool("IsRunning", true);
        }

        if(_playerInputH == 0)
        {
            _animator.SetBool("IsRunning", false);
        }  
    }

    void Jump()
    {
        _rBody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);

        _animator.SetBool("IsJumping", true);
    }
}
