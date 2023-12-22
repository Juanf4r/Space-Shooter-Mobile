using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject laserBullet;
    [SerializeField] private Transform basicShootPoint;
    [SerializeField] private float shootingInterval;

    private float _intervalReset;

    void Start()
    {
        _intervalReset = shootingInterval;
    }

    // Update is called once per frame
    void Update()
    {
        shootingInterval -= Time.deltaTime;
        if(shootingInterval <= 0)
        {
            Shoot();
            shootingInterval = _intervalReset;
        }
    }

    private void Shoot()
    {
        Instantiate(laserBullet,basicShootPoint.position, Quaternion.identity);
    }
}
