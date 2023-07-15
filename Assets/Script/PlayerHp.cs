using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    [SerializeField] int _maxHp = 100;
    float _currentHp;
    Slider _slider;
    // Start is called before the first frame update
    void Start()
    {
        _slider = GameObject.Find("Hp").GetComponent<Slider>();
        _slider.value = 1;

        _currentHp = _maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        _slider.value = (float)_currentHp / (float)_maxHp;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            _currentHp = _currentHp -10;
        }
    }
}
