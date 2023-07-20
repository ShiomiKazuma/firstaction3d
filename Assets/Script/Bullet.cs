using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _bulletSpeed = 1.0f;
    Rigidbody _bulletRb;
    float _timer;
    float _bulletDeathCount = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        _bulletRb = GetComponent<Rigidbody>();
        Vector3 vec = new Vector3(0, 1, 1).normalized * _bulletSpeed;
        _bulletRb.AddForce(vec, ForceMode.Impulse);
        _timer = 0;
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
