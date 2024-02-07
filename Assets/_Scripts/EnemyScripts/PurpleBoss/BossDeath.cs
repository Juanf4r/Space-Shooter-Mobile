using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeath : BossBaseState
{
    public override void RunState()
    {
        EndGameManager.Instance.possibleWin = true;
        EndGameManager.Instance.StartResolveFunction();
        gameObject.SetActive(false);
    }
}
