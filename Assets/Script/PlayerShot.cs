using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShot : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] GameObject _muzzle;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(_bullet, _muzzle.transform.position, _muzzle.transform.rotation);
        }
    }
}
