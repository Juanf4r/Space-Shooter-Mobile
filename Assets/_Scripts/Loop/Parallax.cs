using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float parallaxSpeed;
    private float _spriteHeight;
    private Vector3 _startPos;

    private void Start()
    {
        _startPos = transform.position;
        _spriteHeight = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    private void Update()
    {
        transform.Translate(parallaxSpeed * Time.deltaTime * Vector3.down);

        if(transform.position.y < _startPos.y - _spriteHeight)
        {
            transform.position = _startPos;
        }
    }
}
