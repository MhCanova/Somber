using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buffs / Rotation")]

public class RotateUP : PowerUP
{
    public float addRotSpeed;

    public override void ApplyPowerUp(GameObject target)
    {
        target.GetComponent<IsoCharacterController>().turnSpeed += addRotSpeed;
    }
}
