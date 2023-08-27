using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MizePlayerMove : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField] float _playerSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 velocity = new Vector3(x, 0, z);

        _rb.AddForce(velocity * _playerSpeed, ForceMode.Force);
    }
}
