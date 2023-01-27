using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : EnemyBase
{
    [SerializeField] protected float _waitDurationOnHit = 1f;
    
    protected override void OnHit()
    {
        StartCoroutine(ModifySpeed(_waitDurationOnHit));
    }

    IEnumerator ModifySpeed(float duration)
    {
        float originalSpeed = MoveSpeed;
        MoveSpeed = 0;

        yield return new WaitForSeconds(duration);

        MoveSpeed = originalSpeed;
    }
}
