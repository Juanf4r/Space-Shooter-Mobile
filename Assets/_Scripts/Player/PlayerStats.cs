using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private Animator anim;
    [SerializeField] private Image healthFill;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private Shield shield;

    private PlayerShooting _playerShooting;
    private float _health;
    private bool _canPlayAnim = true;

    public bool canTakeDmg = true;

    private void OnEnable()
    {
        _health = maxHealth;
        healthFill.fillAmount = _health/maxHealth;
        EndGameManager.Instance.gameOver = false;
        StartCoroutine(DamageProtection());
    }

    private void Start()
    {
        _playerShooting = GetComponent<PlayerShooting>();
        EndGameManager.Instance.RegisterPlayerStats(this);
        EndGameManager.Instance.possibleWin = false;
    }

    private IEnumerator DamageProtection()
    {
        canTakeDmg = true;
        yield return new WaitForSeconds(1.5f);
    }

    public void PlayerTakeDamage(float damage)
    {
        if(canTakeDmg == false)
        {
            return;
        }

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
            gameObject.SetActive(false);
            //Destroy(gameObject);
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
