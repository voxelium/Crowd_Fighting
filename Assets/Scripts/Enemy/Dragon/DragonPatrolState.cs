using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DragonPatrolState : StateMachineBehaviour
{
    float timer;
    List<Transform> PatrolPoints = new List<Transform>();
    NavMeshAgent agent;
    Transform player;
    float chaseRange = 5;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 0.5f;
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timer = 0;
        GameObject patrolPointsGroup = GameObject.FindGameObjectWithTag("DragonPatrolPoints");

        foreach (Transform point in patrolPointsGroup.transform)
        {
            PatrolPoints.Add(point.transform);
        }

        SetRandomPatrolPoint();
    }



    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;

        // stop patroling
        if (timer > 20)
        {
            animator.SetBool("isPatroling", false);
        }

        //change patrol point
        if (agent.remainingDistance <= agent.stoppingDistance)
           
        {
            SetRandomPatrolPoint();
        }


        // Start chasing the player
        if (player)
        {
            float chaseDistance = Vector3.Distance(player.position, animator.transform.position);

            if (chaseDistance < chaseRange)
            {
                animator.SetBool("isChasing", true);
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }

    private void SetRandomPatrolPoint()
    {
        agent.SetDestination(PatrolPoints[Random.Range(0, PatrolPoints.Count)].position);
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
