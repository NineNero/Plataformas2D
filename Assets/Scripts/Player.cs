using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Player : MonoBehaviour
{
    [Header("Player Stats")]
    [Tooltip("Controla la velocidad de movimiento del personaje")]
    [SerializeField]private float _playerSpeed = 5;
    [Tooltip("Controla la fueza de salto del personaje")]
    [SerializeField]private float _jumpForce = 5;
    private float _playerInputH;

    private Rigidbody2D _rBody2D;
    //private GroundSensor _sensor;
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayableDirector _director;

    void Start()
    {
        _rBody2D = GetComponent<Rigidbody2D>();
        //_sensor = GetComponentInChildren<GroundSensor>();
    }

    void Update()
    {
        PlayerMovement();

        if(Input.GetButtonDown("Jump") && GroundSensor._isGrounded)
        {
            Jump();
        }

        if(Input.GetButtonDown("Fire2"))
        {
            _director.Play();
        }
    }

    void FixedUpdate()
    {
       _rBody2D.velocity = new Vector2(_playerInputH * _playerSpeed, _rBody2D.velocity.y);
    }

    void PlayerMovement()
    {
        _playerInputH = Input.GetAxis("Horizontal");

        if(_playerInputH < 0)
        {
            //_renderer.flipx = true;
            transform.rotation = Quaternion.Euler(0, 180, 0);
            _animator.SetBool("IsRunning", true);
        }

        else if(_playerInputH > 0)
        {
            //_renderer.flipx = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            _animator.SetBool("IsRunning", true);
        }

        else
        {
            _animator.SetBool("IsRunning", false);
        }

    }

    void Jump()
    {
        _rBody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        _animator.SetBool("IsJumping", true);
    }

    public void SignalTest()
    {
        Debug.Log("Senal recibida");
    }
}
