using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolPoints : MonoBehaviour
{
    [SerializeField] private Transform[] patrolPoints;
    public Transform targetPoint;
    private NavMeshAgent enemyNavMeshAgent;

    private bool definitionMethod = true;
    private int PointCount;

    private void Start()
    {
        enemyNavMeshAgent = GetComponent<NavMeshAgent>();
        PointCount = 0;
        targetPoint = patrolPoints[PointCount];
        enemyNavMeshAgent.SetDestination(patrolPoints[PointCount].position);
    }


    private void Update()
    {
        if (enemyNavMeshAgent.remainingDistance <= 0.2f)
        {
            DefinitionTargets();
        }
    }


    public void DefinitionTargets()
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
        PointCount++;
        targetPoint = patrolPoints[PointCount];

        if (PointCount >= patrolPoints.Length)
        {
            definitionMethod = false;
            PointCount--;
            DefinitionTargets();
        }
    }


    private void DecreaseTargetInt()
    {
        PointCount--;
        targetPoint = patrolPoints[PointCount];

        if (PointCount <= -1)
        {
            definitionMethod = true;
            PointCount++;
            DefinitionTargets();
        }
    }



}