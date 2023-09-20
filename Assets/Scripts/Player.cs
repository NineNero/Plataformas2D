using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float _playerSpeed = 5;
    private float _playerInputH;
    //private float _playerInputV;

    private Rigidbody2D _rBody2D;

    // Start is called before the first frame update
    void Start()
    {
        _rBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void FixedUpdate()
    {
        _rBody2D.AddForce(new Vector2(_playerInputH * _playerSpeed, 0));
    }

    void PlayerMovement()
    {
        _playerInputH = Input.GetAxis("Horizontal");
        /*_playerInputV = Input.GetAxis("Vertical");

        transform.Translate(new Vector2(_playerInputH, _playerInputV) * _playerSpeed * Time.deltaTime);*/
    }
}
