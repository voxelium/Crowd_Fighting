using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] private float HP = 100;


    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if (HP <= 0)
        {
            //Play animation Death
            animator.SetTrigger("Die");
            GetComponent<Collider>().enabled = false;
        }
        else
        {
            //Play get hit animation
            animator.SetTrigger("Damage");
            Debug.Log("damage" + damageAmount);
        }
    }
}
