using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    [Header("Power Up Settings")]
    [SerializeField] protected float _duration = 2f;
    
    [Header("Feedback")]
    [SerializeField] protected AudioClip _collectSFX = null;

    protected abstract void PowerUp();
    protected abstract void PowerDown();

    private void OnTriggerEnter(Collider other)
    {
        Projectile projectile = other.GetComponent<Projectile>();
        if (projectile != null)
        {
            if (_collectSFX != null)
            {
                AudioHelper.PlayClip2D(_collectSFX, 1, .1f);
            }
            StartCoroutine(OnHit());
        }
    }

    protected IEnumerator OnHit()
    {
        PowerUp();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(_duration);

        PowerDown();
        Destroy(gameObject);
    }
}
