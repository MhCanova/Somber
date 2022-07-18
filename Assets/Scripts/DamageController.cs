using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] private int Damage;
    [SerializeField] private HPController hpManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DamageDealer();
        }
    }

    void DamageDealer()
    {
        hpManager.playerHP = hpManager.playerHP - Damage;
        hpManager.UpdateHP();

        //Esto es provisorio. La idea es que los bichos vivan mas
        //gameObject.SetActive(false);

    }
}
