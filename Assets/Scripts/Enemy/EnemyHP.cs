using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] public float HP = 100;

    private new Collider collider;

    private void Start()
    {
        collider = GetComponent<Collider>();
    }


    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;

        Debug.Log("Enemy HP: " + HP);

        if (HP <= 0)
        {
            //Play animation Death
            animator.SetTrigger("Death");

            StartCoroutine(SetCollisionFalse());
            agent.isStopped = true;
        }
        else
        {
            //Play get hit animation
            animator.SetTrigger("Damage");
        }
    }


    IEnumerator SetCollisionFalse()
    {
        yield return new WaitForSeconds(2f);
        collider.enabled = false;
    }

}
