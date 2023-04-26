using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Animator animator;
    Transform enemy;

    private void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            animator.SetBool("Kick", true);
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
