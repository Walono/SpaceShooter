﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderLife : MonoBehaviour
{
    [SerializeField]
    private float _health;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "SpaceShip")
        {
            Destroy(collision.gameObject);
        }

        Munitions munType = collision.gameObject.GetComponentInParent<Munitions>();
        if (munType != null)
        {
            AssignDammage(munType.GetMunPower(0));
            Destroy(collision.gameObject);
        }
    }

    private void AssignDammage(int dammage)
    {
        _health -= dammage;
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}