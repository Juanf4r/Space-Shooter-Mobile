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
        if (EndGameManager.Instance.gameOver == true)
            return;

        _timer += Time.deltaTime;
        if(_timer >= possibleWinTime)
        {
            for(int i = 0; i < spawner.Length; i++)
            {
                spawner[i].SetActive(false);
                
            }
            EndGameManager.Instance.StartResolveFunction();
            gameObject.SetActive(false);
        }
    }
}
