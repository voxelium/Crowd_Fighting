using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class EnemyChaseState : StateMachineBehaviour
{
    Transform player;
    Transform targetPatrolPoint;
    NavMeshAgent agent;
    float stopChaseRange = 4;
    float startAttackRange = 2;
    Vector3 currentPatrolPoint;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        currentPatrolPoint = animator.GetComponent<EnemyPatrolMovement>().targetPointPosition;

        if (GameObject.FindGameObjectWithTag("Player"))
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player != null)
        {
            agent.SetDestination(player.position);
            float distanceToPlayer = Vector3.Distance(player.position, animator.transform.position);

            //Stop chasing condition
            if (distanceToPlayer > stopChaseRange)
            {
                agent.SetDestination(currentPatrolPoint);
                animator.SetBool("isChasing", false);
            }

            //Start attack condition
            if (distanceToPlayer < startAttackRange)
            {
                animator.SetBool("isAttacking", true);
            }
        }
        else if (player == null)
        {
            agent.SetDestination(currentPatrolPoint);
            animator.SetBool("isChasing", false);
        }
            
    }


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
