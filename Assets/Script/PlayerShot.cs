using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShot : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] GameObject _muzzle;
    bool _bulletButtonDown = false;
    public float _bulletCharge;
    [SerializeField] float _bulletChargeMax = 100.0f;

    //public float BulletCharge
    //{
    //    get { return _bulletCharge; }

    //    private set
    //    {
    //        _bulletCharge = value;
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            
            _bulletButtonDown =true;
        }

        if(_bulletButtonDown)
        {
            _bulletCharge += 2.0f;

            if(_bulletCharge > _bulletChargeMax)
            {
                _bulletCharge = _bulletChargeMax;
            }

        }

        if(Input.GetButtonUp("Fire1"))
        {
            Instantiate(_bullet, _muzzle.transform.position, _muzzle.transform.rotation);
            _bulletButtonDown = false;
        }
    }

    
}
