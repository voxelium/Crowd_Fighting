using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]

public class FightFootElement : MonoBehaviour
{
    [SerializeField] private int damageAmount = 10;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyHP>().TakeDamage(damageAmount);
            Debug.Log("Удар по врагу");
        }
    }


    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.tag == "Enemy")
    //    {
    //        other.GetComponent<EnemyHP>().TakeDamage(damageAmount);
    //        Debug.Log("Удар по врагу");
    //    }
    //}
}
