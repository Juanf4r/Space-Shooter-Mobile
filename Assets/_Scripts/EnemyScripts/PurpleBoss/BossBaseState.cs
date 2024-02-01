using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBaseState : MonoBehaviour
{
    protected Camera _mainCam;

    protected float _maxLeft;
    protected float _maxRight;
    protected float _maxDown;
    protected float _maxUp;
    protected BossController _bossController;

    private void Awake()
    {
        _bossController = GetComponent<BossController>();
        _mainCam = Camera.main;
    }

    protected virtual void Start()
    {
        _maxLeft = _mainCam.ViewportToWorldPoint(new Vector2(0.3f, 0)).x;
        _maxRight = _mainCam.ViewportToWorldPoint(new Vector2(0.7f, 0)).x;

        _maxDown = _mainCam.ViewportToWorldPoint(new Vector2(0, 0.6f)).y;
        _maxUp = _mainCam.ViewportToWorldPoint(new Vector2(0, 0.9f)).y;
    }

    public virtual void RunState()
    {

    }

    public virtual void StopState()
    {
        StopAllCoroutines();
    }
}
