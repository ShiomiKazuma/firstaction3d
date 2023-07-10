using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float _playerMoveX;
    float _playerMoveZ;
    [SerializeField] public float _playerMoveSpeed = 1.0f;
    private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _playerMoveX = Input.GetAxisRaw("Horizontal");
        _playerMoveZ = Input.GetAxisRaw("Vertical");

        _rb.velocity = new Vector3(_playerMoveX, 0, _playerMoveZ).normalized * _playerMoveSpeed;
        
    }
}
