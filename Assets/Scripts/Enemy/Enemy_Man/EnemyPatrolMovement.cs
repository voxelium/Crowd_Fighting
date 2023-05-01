using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolMovement : MonoBehaviour
{
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private Animator enemyAnimator;
    private NavMeshAgent enemyNavMeshAgent;

    private int targetPoint = 0;
    private bool definitionMethod = true;
    [HideInInspector] public Vector3 targetPointPosition;

    private void Start()
    {
        targetPoint = 0;
        enemyNavMeshAgent = GetComponent<NavMeshAgent>();
        SetTargetPointPosition();
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
        //enemyAnimator.SetFloat("EnemyAnimBlend", enemyNavMeshAgent.speed);

        //Вариант смены точки патрулирования без использования Триггеров пересечения
        //но использование update лучше все-таки избегать. Вариант с Триггером менее затратный
        //if (enemyNavMeshAgent.remainingDistance <= 0.2f)
        //{
        //    DefinitionTargets();
        //}


        // Прыгает если обнаружена область OffMeshLink
        //if (enemyNavMeshAgent.isOnOffMeshLink)
        //{
        //    var meshLink = enemyNavMeshAgent.currentOffMeshLinkData;

        //    if (meshLink.offMeshLink.area == NavMesh.GetAreaFromName("Jump"))
        //    {
        //        enemyAnimator.Play("Jump");
        //    }

        //}

        if (enemyNavMeshAgent.isOnOffMeshLink)
        {
            enemyAnimator.Play("Jump");
        } 
    

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

        SetTargetPointPosition();
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

        SetTargetPointPosition();

    }

    public void SetTargetPointPosition()
    {
        targetPointPosition = patrolPoints[targetPoint].position;
        enemyNavMeshAgent.SetDestination(targetPointPosition);
    }

}
