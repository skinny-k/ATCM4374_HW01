using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charger : EnemyBase
{
    [Header("Charger Settings")]
    [SerializeField] protected float _speedModifierPerHit = 1.5f;
    
    protected override void OnHit()
    {
        MoveModifier *= _speedModifierPerHit;
    }
}
