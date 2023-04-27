using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] private float HP = 100;


    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;

        Debug.Log("Enemy HP: " + HP);

        if (HP <= 0)
        {
            //Play animation Death
            animator.SetTrigger("Death");
            GetComponent<Collider>().enabled = false;
            agent.enabled = false;
        }
        else
        {
            //Play get hit animation
            animator.SetTrigger("Damage");

            //Debug.Log("damage" + damageAmount);
        }
    }
}
