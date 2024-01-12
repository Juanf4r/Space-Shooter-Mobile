using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenEnemy : Enemy
{
    [SerializeField] private float speed;
   

    private void Start()
    {
        rb.velocity = Vector2.down * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStats>().PlayerTakeDamage(damage);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public override void HurtSequence()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Dmg"))
            return;
        anim.SetTrigger("Damage");
    }

    public override void DeathSequence()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
