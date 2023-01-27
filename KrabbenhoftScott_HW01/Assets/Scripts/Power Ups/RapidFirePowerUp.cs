using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFirePowerUp : PowerUpBase
{
    [SerializeField] float _fireCooldownReductionPercentage = 0.5f;
    
    protected override void PowerUp()
    {
        TurretController.FireCooldown *= _fireCooldownReductionPercentage;
    }

    protected override void PowerDown()
    {
        TurretController.FireCooldown /= _fireCooldownReductionPercentage;
    }
}
