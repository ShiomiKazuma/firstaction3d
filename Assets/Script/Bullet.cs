using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody _bulletRb;
    float _timer;
    float _bulletDeathCount = 3.0f;
    float _bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        _bulletRb = GetComponent<Rigidbody>();

        PlayerShot playerShot = GameObject.Find("Player").GetComponent<PlayerShot>();
        _bulletSpeed = playerShot._bulletCharge;

        Debug.Log(playerShot._bulletCharge);
        Vector3 vec = transform.TransformDirection(0, 1, 1).normalized * _bulletSpeed;
        _bulletRb.AddForce(vec, ForceMode.Impulse);
        _timer = 0;
        playerShot._bulletCharge = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if(_timer > _bulletDeathCount)
        {
            Destroy(this.gameObject);
        }
    }
}
