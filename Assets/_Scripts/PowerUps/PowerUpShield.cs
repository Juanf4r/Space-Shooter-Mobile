using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpShield : MonoBehaviour
{
    [SerializeField] private AudioClip clipToPlay;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            PlayerShieldActivator shieldActivator = collision.GetComponent<PlayerShieldActivator>();
            shieldActivator.ActivateShield();
            AudioSource.PlayClipAtPoint(clipToPlay,transform.position,1f);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
