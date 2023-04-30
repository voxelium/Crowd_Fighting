using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && other.GetComponent<EnemyHP>().currentHP > 0)
        {
            animator.SetBool("Kick", true);
        }

    }

    //void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.tag == "Enemy" && other.GetComponent<EnemyHP>().currentHP > 0)
    //    {
    //        animator.SetBool("Kick", true);

    //        Debug.Log(other.name);
    //    }
        
    //}


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            animator.SetBool("Kick", false);

            Debug.Log("пора выключить атаку");

        }

    }
 
}
