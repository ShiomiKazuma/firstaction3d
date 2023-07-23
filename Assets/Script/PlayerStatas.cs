using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatas : MonoBehaviour
{
    public PlayerSt _playerSt = PlayerSt.Normal;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Poision")
        {
            _playerSt = PlayerSt.Poision;

        }
    }
    public enum PlayerSt
    {
        Normal,
        Poision,
    }
}
