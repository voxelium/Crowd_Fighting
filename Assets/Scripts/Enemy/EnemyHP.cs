using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Slider healthBar;
    [SerializeField] private float maxHP = 100;
    public float currentHP;

    private new Collider collider;

    private void Start()
    {
        collider = GetComponent<Collider>();
        currentHP = maxHP;
    }

    private void Update()
    {
        healthBar.value = currentHP / maxHP;
    }


    public void TakeDamage(int damageAmount)
    {
        currentHP -= damageAmount;

        if (currentHP <= 0)
        {
            //Play animation Death
            animator.SetTrigger("Death");
            agent.isStopped = true;
            collider.enabled = false;
            StartCoroutine(DestroyEnemy());
         
        }
        else
        {
            //Play get hit animation
            animator.SetTrigger("Damage");
        }
    }



    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }

}
