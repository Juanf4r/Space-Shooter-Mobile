using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeath : BossBaseState
{
    public override void RunState()
    {
        EndGameManager.Instance.StartResolveFunction();
        gameObject.SetActive(false);
    }
}
