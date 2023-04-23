using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private NavMeshAgent enemyNavMeshAgent;
    [SerializeField] private Animator enemyAnimator;

    public int targetPoint = 0;
    private bool definitionMethod = true;

    private void Start()
    {
        targetPoint = 0;
        enemyNavMeshAgent = GetComponent<NavMeshAgent>();
        enemyNavMeshAgent.SetDestination(patrolPoints[targetPoint].position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == patrolPoints[targetPoint])
        {
            DefinitionTargets();
        }
    }



    private void Update()
    {
        enemyAnimator.SetFloat("EnemyAnimBlend", enemyNavMeshAgent.speed);


        //Вариант смены точки патрулирования без использования Триггеров пересечения
        //но использование update лучше все-таки избегать. Вариант с Триггером менее затратный
        //if (enemyNavMeshAgent.remainingDistance <= 0.2f)
        //{
        //    DefinitionTargets();
        //}
    }


    private void DefinitionTargets()
    {
        if (definitionMethod == true)
        {
            IncreaseTargetInt();
        }
        else
        {
            DecreaseTargetInt();
        }
    }


    private void IncreaseTargetInt()
    {
        targetPoint++;

        if (targetPoint >= patrolPoints.Length)
        {
            definitionMethod = false;
            targetPoint --;
            DefinitionTargets();
        }

        enemyNavMeshAgent.SetDestination(patrolPoints[targetPoint].position);
    }


    private void DecreaseTargetInt()
    {
        targetPoint--;

        if (targetPoint <= -1)
        {
            definitionMethod = true;
            targetPoint ++;
            DefinitionTargets();
        }

        enemyNavMeshAgent.SetDestination(patrolPoints[targetPoint].position);

    }

}
