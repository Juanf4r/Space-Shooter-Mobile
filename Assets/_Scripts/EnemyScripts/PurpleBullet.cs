using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleBullet : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = Vector2.down * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStats>().PlayerTakeDamage(damage);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
