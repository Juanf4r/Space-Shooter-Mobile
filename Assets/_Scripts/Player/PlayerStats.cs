using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float _health;

    [SerializeField] private Image healthFill;
    void Start()
    {
        _health = maxHealth;
        healthFill.fillAmount = _health/maxHealth;
    }

    public void PlayerTakeDamage(float damage)
    {
        _health -= damage;
        healthFill.fillAmount = _health / maxHealth;
        if (_health <= 0 )
        {
            Destroy(gameObject);
        }
    }
}
