using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    /// <summary>ƒWƒƒƒ“ƒv—Í </summary>
    [SerializeField] float _jumpPower = 1.0f;
    Rigidbody _rb;
    int _jumpCount; 
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && _jumpCount < 2)
        {
            _rb.AddForce(transform.up * _jumpPower, ForceMode.Impulse);
            _jumpCount++;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            _jumpCount = 0;
        }
    }
}
