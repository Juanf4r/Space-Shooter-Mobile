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
    [SerializeField] private Shield shield;

    private PlayerShooting _playerShooting;

    void Start()
    {
        _health = maxHealth;
        healthFill.fillAmount = _health/maxHealth;
        EndGameManager.Instance.gameOver = false;
        _playerShooting = GetComponent<PlayerShooting>();
    }

    public void PlayerTakeDamage(float damage)
    {
        if (shield.protection)
        {
            return;
        }
            
        _health -= damage;
        healthFill.fillAmount = _health / maxHealth;

        if(_canPlayAnim == true)
        {
            anim.SetTrigger("Damage");
            StartCoroutine(AntiSpamFunction());
        }

        _playerShooting.DecreaseUpgrade();
        
        if (_health <= 0 )
        {
            EndGameManager.Instance.gameOver = true;
            EndGameManager.Instance.StartResolveFunction();
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void AddHealth(int healAmount)
    {
        _health += healAmount;
        if(_health >= maxHealth )
        {
            _health = maxHealth;
        }
        healthFill.fillAmount = _health / maxHealth;
    }

    private IEnumerator AntiSpamFunction()
    {
        _canPlayAnim = false;
        yield return new WaitForSeconds(0.15f);
        _canPlayAnim = true;
    }
}
