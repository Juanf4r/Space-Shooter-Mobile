using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : Enemy
{
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    private float _speed;

    void Start()
    {
        _speed = Random.Range(minSpeed, maxSpeed);
        rb.velocity = Vector2.down * _speed;
    }

    void Update()
    {
        transform.Rotate(0,0,rotateSpeed * Time.deltaTime);
    }

    public override void HurtSequence()
    {
        //do something else
    }

    public override void DeathSequence()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D otherColl)
    {
        if (otherColl.CompareTag("Player"))
        {
            //Destroy(otherColl.gameObject);
            PlayerStats player = otherColl.GetComponent<PlayerStats>();
            player.PlayerTakeDamage(damage);

            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
