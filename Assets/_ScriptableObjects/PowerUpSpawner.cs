using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="ScriptableObject/PowerUpSpawner",fileName ="Spawner")]

public class PowerUpSpawner : ScriptableObject
{
    public int spwnThreshold;
    public GameObject[] powerUp;

    public void SpawnPowerUp(Vector3 spawnPos)
    {
        int randomChance = Random.Range(0, 100);

        if(randomChance > spwnThreshold)
        {
            int randomPowerUp = Random.Range(0, powerUp.Length);
            Instantiate(powerUp[randomPowerUp], spawnPos, Quaternion.identity);
        }
    }
}
