using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnter : BossBaseState
{
    private Vector2 _enterPoint;
    [SerializeField] private float speed;

    protected override void Start()
    {
        base.Start();
        _enterPoint = _mainCam.ViewportToWorldPoint(new Vector2(0.5f, 0.7f));
    }

    public override void RunState()
    {
        StartCoroutine(RunEnterState());
    }

    public override void StopState()
    {
        base.StopState();
    }

    private IEnumerator RunEnterState()
    {
        while(Vector2.Distance(transform.position, _enterPoint) > 0.01f)
        {
            transform.position = Vector2.MoveTowards(transform.position, _enterPoint, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        _bossController.ChangeState(BossState.fire);
    }
}
