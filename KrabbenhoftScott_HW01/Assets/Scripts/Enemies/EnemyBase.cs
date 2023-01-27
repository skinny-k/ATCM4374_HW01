using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] private int _health = 3;
    [SerializeField] GameObject _dropsOnDeath = null;
    [SerializeField] float _chanceToDrop = 0.5f;

    [Header("FX")]
    [SerializeField] private AudioClip _deathSound;
    [SerializeField] private AudioClip _hitSound;
    [SerializeField] protected float MoveSpeed = .05f;

    protected float MoveModifier = 1f;
    protected Rigidbody RB { get; private set; }

    protected abstract void OnHit();

    private void Awake()
    {
        RB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }
    
    protected virtual void Move()
    {
        Vector3 moveDelta = transform.forward * MoveSpeed * MoveModifier;
        RB.MovePosition(RB.position + moveDelta);
    }

    private void OnTriggerEnter(Collider other)
    {
        Projectile projectile = other.GetComponent<Projectile>();
        if (projectile != null)
        {
            _health -= 1;
            AudioHelper.PlayClip2D(_hitSound, 1, .1f);
            OnHit();
            if (_health <= 0)
            {
                Kill();
            }
        }
    }

    public virtual void Kill()
    {
        AudioHelper.PlayClip2D(_deathSound, 1, .1f);

        if (_dropsOnDeath != null && _chanceToDrop != 0)
        {
            Instantiate(_dropsOnDeath, transform.position, Quaternion.identity);
        }

        gameObject.SetActive(false);
    }
}
