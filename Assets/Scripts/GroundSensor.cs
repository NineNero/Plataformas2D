using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    private Animator _animator;
    
    public static bool _isGrounded;

    void Start()
    {
        _animator = GameObject.Find("knight").GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 6)
        {
            _isGrounded = true;
            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.layer == 6)
        {
            _isGrounded = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.layer == 6)
        {
            _isGrounded = true;
        }
    }
}
