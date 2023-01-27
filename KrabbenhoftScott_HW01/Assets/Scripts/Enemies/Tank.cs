using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : EnemyBase
{
    [Header("Tank Settings")]
    [SerializeField] protected float _waitDurationOnHit = 1f;
    
    protected override void OnHit()
    {
        StartCoroutine(ModifySpeed(_waitDurationOnHit));
    }

    IEnumerator ModifySpeed(float duration)
    {
        MoveModifier = 0;

        yield return new WaitForSeconds(duration);

        MoveModifier = 1;
    }
}
