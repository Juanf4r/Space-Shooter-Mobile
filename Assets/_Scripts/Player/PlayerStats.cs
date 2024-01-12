using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float _health;
    private bool _canPlayAnim = true;

    [SerializeField] private Animator anim;
    [SerializeField] private Image healthFill;
    [SerializeField] private GameObject explosionPrefab;

    void Start()
    {
        _health = maxHealth;
        healthFill.fillAmount = _health/maxHealth;
    }

    public void PlayerTakeDamage(float damage)
    {
        _health -= damage;
        healthFill.fillAmount = _health / maxHealth;

        if(_canPlayAnim == true)
        {
            anim.SetTrigger("Damage");
            StartCoroutine(AntiSpamFunction());
        }
        
        if (_health <= 0 )
        {
            EndGameManager.Instance.gameOver = true;
            EndGameManager.Instance.StartResolveFunction();
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private IEnumerator AntiSpamFunction()
    {
        _canPlayAnim = false;
        yield return new WaitForSeconds(0.15f);
        _canPlayAnim = true;
    }
}
