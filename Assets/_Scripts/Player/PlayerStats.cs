using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float _health;
    void Start()
    {
        _health = maxHealth;
    }

    public void PlayerTakeDamage(float damage)
    {
        _health -= damage;
        if(_health < 0 )
        {
            Destroy(gameObject);
        }
    }
}
