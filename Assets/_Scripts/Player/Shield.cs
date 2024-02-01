using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private int _hitsToDestroy = 3;
    public bool protection = false;

    [SerializeField] private GameObject[] shieldBase;

    private void OnEnable()
    {
        _hitsToDestroy = 3;
        for(int i = 0; i < shieldBase.Length; i++)
        {
            shieldBase[i].SetActive(true);
        }
        protection = true;
    }

    private void updateUI()
    {
        switch (_hitsToDestroy)
        {
            case 0:
                for (int i = 0; i < shieldBase.Length; i++)
                {
                    shieldBase[i].SetActive(false);
                }
                break;

            case 1:
                shieldBase[0].SetActive(true);
                shieldBase[1].SetActive(false);
                shieldBase[2].SetActive(false);
                break;

            case 2:
                shieldBase[0].SetActive(true);
                shieldBase[1].SetActive(true);
                shieldBase[2].SetActive(false);
                break;

            case 3:
                shieldBase[0].SetActive(true);
                shieldBase[1].SetActive(true);
                shieldBase[2].SetActive(true);
                break;

            default:
                Debug.Log("we dont have this case, something is wrong");
                break;
        }
    }

    private void DamageShield()
    {
        _hitsToDestroy--;
        if(_hitsToDestroy <= 0 )
        {
            _hitsToDestroy = 0;
            protection = false;
            gameObject.SetActive(false);
        }
        updateUI();
    }

    public void RepairShield()
    {
        _hitsToDestroy = 3;
        updateUI();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(100000);
            DamageShield();
        }
        else
        {
            Destroy(collision.gameObject);
            DamageShield();
        }
    }
}
