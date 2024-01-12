using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleEnemy : Enemy
{
    [SerializeField] private float speed;
    [SerializeField] private float shootInterval;
    private float _shootTimer = 0;

    [SerializeField] private Transform leftCanon;
    [SerializeField] private Transform rightCanon;
    [SerializeField] private GameObject bulletPrefab;

    private void Start()
    {
        rb.velocity = Vector2.down * speed;
    }

    private void Update()
    {
        _shootTimer += Time.deltaTime;
        if(_shootTimer >= shootInterval)
        {
            Instantiate(bulletPrefab, leftCanon.position, Quaternion.identity);
            Instantiate(bulletPrefab, rightCanon.position, Quaternion.identity);

            _shootTimer = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStats>().PlayerTakeDamage(damage);
            Instantiate(explosionPrefab,transform.position, Quaternion.identity);
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
