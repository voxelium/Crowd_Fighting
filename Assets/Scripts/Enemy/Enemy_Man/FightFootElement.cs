using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightFootElement : MonoBehaviour
{
    [SerializeField] private int damageAmount = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Dragon>().TakeDamage(damageAmount);
        }
    }
}
