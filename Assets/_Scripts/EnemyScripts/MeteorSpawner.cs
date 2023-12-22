using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] meteor;
    [SerializeField] private float spawnTime;
    private float _timer = 0f;
    private int _index;

    private Camera _mainCam;
    private float _maxLeft, _maxRight, _yPos;

    void Start()
    {
        _mainCam = Camera.main;
        StartCoroutine(SetBoundaries());
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if(_timer > spawnTime)
        {
            _index = Random.Range(0,meteor.Length);
            GameObject obj = Instantiate(meteor[_index], new Vector3(Random.Range(_maxLeft,_maxRight), _yPos, -5),Quaternion.Euler(0,0,Random.Range(0,360)));
            float size = Random.Range(0.9f, 1.1f);
            obj.transform.localScale = new Vector3(size, size, 1);   
            _timer = 0f;
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
