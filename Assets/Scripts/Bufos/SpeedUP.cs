using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Buffs / Speed")]

public class SpeedUP : PowerUP
{
    public float addSpeed;

    public override void ApplyPowerUp(GameObject target)
    {
        target.GetComponent<IsoCharacterController>().speed += addSpeed;
    }
}
