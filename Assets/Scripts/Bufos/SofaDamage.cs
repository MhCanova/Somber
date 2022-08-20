using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SofaDamage : DamageController
{
    protected override void Intro()

    {
        Debug.Log("Te surtio un mueble");
    }

    protected override void EnemyEraser()
    {
        Debug.Log("Sali de aca gato.");
    }

}
