using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected Rigidbody2D rb;
    void Start()
    {
        
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        HurtSequence();

        if (health <= 0)
        {
            DeathSequence();
        }
    }

    public virtual void HurtSequence()
    {
        //do something
    }

    public virtual void DeathSequence()
    {
        //do something
    }
}
