using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MizePlayerMove : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField] float _moveSpeed = 10f;
    [SerializeField] float _cameraSpeed = 10f;
    float x, z;
    Vector3 velocity;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        velocity = cameraForward * z + Camera.main.transform.right * x;

        //マウスでカメラの視点を操作する
        float cameraX = Input.GetAxis ("Mouse X") * _cameraSpeed;
        transform.RotateAround(transform.position, Vector3.up, cameraX);
    }
    private void FixedUpdate()
    {
        _rb.velocity = velocity * _moveSpeed;
    }
}