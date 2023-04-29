using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator animator;




    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //    {
    //        Debug.Log("Столкновение с врагом");

    //        animator.SetBool("Kick", true);
    //    }
    //}


    //private void OnCollisionStay(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //    {
    //        animator.SetBool("Kick", true);
    //    }
    //}


    //private void OnCollisionExit(Collision collision)
    //{
    //if (collision.gameObject.tag == "Enemy")
    //{
    //animator.SetBool("Kick", false);
    //}
    //}



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && other.GetComponent<EnemyHP>().currentHP > 0)
        {
            animator.SetBool("Kick", true);
        }
        else if (other.tag != "Enemy")
        {
            animator.SetBool("Kick", false);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy" && other.GetComponent<EnemyHP>().currentHP > 0)
        {
            animator.SetBool("Kick", true);
            Debug.Log("Enemy tag: " + other.tag + " Health: " + other.GetComponent<EnemyHP>().currentHP);
        }
        else if (other.tag == "Enemy" && other.GetComponent<EnemyHP>().currentHP <= 0)
        {
            animator.SetBool("Kick", false);
            Debug.Log("Enemy tag: " + other.tag + " Health: " + other.GetComponent<EnemyHP>().currentHP);
        }

        
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            animator.SetBool("Kick", false);
        }
    }


 
}
