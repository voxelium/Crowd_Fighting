using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Animator animator;
    Transform enemy;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Столкновение с врагом");

            animator.SetBool("Kick", true);
        }
    }


    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            animator.SetBool("Kick", true);
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            animator.SetBool("Kick", false);
        }
    }



    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Enemy")
    //    {
    //        animator.SetBool("Kick", true);
    //    }

    //}


    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Enemy")
    //    {
    //        animator.SetBool("Kick", false);
    //    }
    //}

}
