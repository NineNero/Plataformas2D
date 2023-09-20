using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    public bool _isGrounded;

    void OnTriggerEnter2D(Collider2D other)
    {
        _isGrounded = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        _isGrounded = false;
    }
}
