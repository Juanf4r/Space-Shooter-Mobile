using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private float _timer;
    [SerializeField] private float possibleWinTime;
    [SerializeField] private GameObject[] spawner;
    [SerializeField] private bool hasBoss;

    public bool CanSpawnBoss = false;

    private void Update()
    {
        if (EndGameManager.Instance.gameOver == true)
            return;

        _timer += Time.deltaTime;
        if(_timer >= possibleWinTime)
        {
            if (hasBoss == false)
            {
                EndGameManager.Instance.possibleWin = true;
                EndGameManager.Instance.StartResolveFunction();
            }
            else
            {
                CanSpawnBoss = true;
            }

            for (int i = 0; i < spawner.Length; i++)
            {
                spawner[i].SetActive(false);
                
            }
            gameObject.SetActive(false);
        }
    }
}
