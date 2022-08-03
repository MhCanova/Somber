using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUPLogic : MonoBehaviour
{
    public PowerUP powerUp;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        powerUp.ApplyPowerUp(other.gameObject);
    }
}
