using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWalkState : StateMachineBehaviour
{
    float timer;
    NavMeshAgent enemyNavMeshAgent;
    private Transform targetPoint;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        enemyNavMeshAgent = animator.GetComponent<NavMeshAgent>();

        targetPoint = animator.GetComponent<EnemyPatrolPoints>().targetPoint;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;

        if (timer > 10)
        {
            animator.SetBool("isPatrolling", false);
            
        }

        if (enemyNavMeshAgent.remainingDistance <= 0.1)

        {
            enemyNavMeshAgent.SetDestination(targetPoint.position);
        }

        //Debug.Log("Target Point: " + targetPoint);

    }

   

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        enemyNavMeshAgent.SetDestination(enemyNavMeshAgent.transform.position);
        
    }

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
