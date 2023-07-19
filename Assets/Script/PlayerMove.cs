using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;
using Vector3 = UnityEngine.Vector3;

public class PlayerMove : MonoBehaviour
{
    float _playerMoveX;
    float _playerMoveZ;
    [SerializeField] float _playerMoveSpeed = 1.0f;
    [SerializeField] float _playerDushSpeed = 10.0f;
    private Rigidbody _rb;
    [SerializeField] int _maxEnergy = 100;
    float _currentEnergy;
    [SerializeField] float _energy = 1;
    [SerializeField] float _recoverEnergy = 1;
    [SerializeField] int _recoverEnergyCount = 0;
    Slider _slider;
    Vector3 _dir;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _slider = GameObject.Find("Slider").GetComponent<Slider>();
        _slider.value = 1;

        _currentEnergy = _maxEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        _playerMoveX = Input.GetAxisRaw("Horizontal");
        _playerMoveZ = Input.GetAxisRaw("Vertical");

        _dir = transform.TransformDirection(_playerMoveX, 0, _playerMoveZ).normalized;

        if (Input.GetKey(KeyCode.LeftShift) && _currentEnergy != 0)
        {
           // _rb.velocity = new Vector3(_playerMoveX, _rb.velocity.y, _playerMoveZ).normalized * _playerDushSpeed;
           Vector3 vec = _dir * _playerDushSpeed;
           vec.y = _rb.velocity.y;
            _rb.velocity = vec;
           _currentEnergy -= _energy;
            if(_currentEnergy <= 0)
            {
                _currentEnergy = 0;
            }
        }
        else
        {
            //_rb.velocity = new Vector3(_playerMoveX, _rb.velocity.y, _playerMoveZ).normalized * _playerMoveSpeed;
            Vector3 vec = _dir * _playerMoveSpeed;
            vec.y = _rb.velocity.y;
            _rb.velocity = vec;
        }


        if (_currentEnergy == 0 && _recoverEnergyCount == 0)
        {
            _recoverEnergyCount = 200;
        }
        else if(_recoverEnergyCount != 0 && _currentEnergy == 0)
        {
            _recoverEnergyCount -= 1;
        }
        
       
        if(_recoverEnergyCount == 0)
        {
            _currentEnergy += _recoverEnergy;
            if(_currentEnergy >= _maxEnergy)
            {
                _currentEnergy = _maxEnergy;
            }
            
        }

        _slider.value = (float)_currentEnergy / (float)_maxEnergy;

        Debug.Log(_currentEnergy);
    }

    private void FixedUpdate()
    {
        if(_dir != Vector3.zero)
        {
            transform.forward = _dir;
        }
    }
}
