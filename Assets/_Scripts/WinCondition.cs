using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private float _timer;
    [SerializeField] private float possibleWinTime;
    [SerializeField] private GameObject[] spawner;

    private void Update()
    {
        _timer += Time.deltaTime;
        if(_timer >= possibleWinTime)
        {
            for(int i = 0; i < spawner.Length; i++)
            {
                spawner[i].SetActive(false);
            }
        }
        EndGameManager.Instance.StartResolveFunction();
        gameObject.SetActive(false);
        // create function that will check if the player survived the last spawned enemy / meteor
        //win or lose
        // GAME MANAGER
    }
}
