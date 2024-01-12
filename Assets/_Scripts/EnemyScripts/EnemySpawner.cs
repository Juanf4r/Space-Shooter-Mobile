using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Camera _mainCam;
    private float _maxLeft, _maxRight, _yPos;

    [Header("Enemy Prefabs")]
    [SerializeField] private GameObject[] enemy;

    private float _enemyTimer;
    [Space(15)]
    [SerializeField] private float enemySpawnTime;

    void Start()
    {
        _mainCam = Camera.main;
        StartCoroutine(SetBoundaries());
    }

    void Update()
    {
        EnemySpawn();
    }

    private void EnemySpawn()
    {
        _enemyTimer += Time.deltaTime;
        if(_enemyTimer >= enemySpawnTime)
        {
            int randomPick = Random.Range(0, enemy.Length);
            Instantiate(enemy[randomPick], new Vector3(Random.Range(_maxLeft,_maxRight),_yPos,0),Quaternion.identity);
            _enemyTimer = 0;
        }
    }

    private IEnumerator SetBoundaries()
    {
        yield return new WaitForSeconds(0.4f);

        _maxLeft = _mainCam.ViewportToWorldPoint(new Vector2(0.15f, 0)).x;
        _maxRight = _mainCam.ViewportToWorldPoint(new Vector2(0.85f, 0)).x;
        _yPos = _mainCam.ViewportToWorldPoint(new Vector2(0, 1.1f)).y;
    }
}
