using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolState : StateMachineBehaviour
{
    Transform player;
    NavMeshAgent enemyNavMeshAgent;
    private Vector3 currentPatrolPoint;
    float timer;
    float chaseRange = 5;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;

        if (GameObject.FindGameObjectWithTag("Player"))
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        

        enemyNavMeshAgent = animator.GetComponent<NavMeshAgent>();
        currentPatrolPoint = animator.GetComponent<EnemyPatrolMovement>().targetPointPosition;
        enemyNavMeshAgent.SetDestination(currentPatrolPoint);

        enemyNavMeshAgent.isStopped = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;

        if (timer > 15)
        {
            animator.SetBool("isPatrolling", false);
            enemyNavMeshAgent.SetDestination(currentPatrolPoint);
        }

        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(player.position, animator.transform.position);

            //Start Chasing
            if (distanceToPlayer < chaseRange)
            {
                animator.SetBool("isChasing", true);
            }
        }
        else if (player == null)
        {
            enemyNavMeshAgent.SetDestination(currentPatrolPoint);
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
