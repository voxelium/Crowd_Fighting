using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_EnemyPatrol : MonoBehaviour
{
    [SerializeField] public Transform[] patrolPoints;
    [SerializeField] private float speed;
    
    private int targetPoint;
    private bool definitionMethod = true;

    private void Start()
    {
        targetPoint = 0;
    }

    private void Update()
    {
        if (transform.position == patrolPoints[targetPoint].position)
        {
            DefinitionTargets();
        }

        // Тестовое перемещение
        //transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);
    }


    private void DefinitionTargets()
    {
        if (definitionMethod)
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
        targetPoint ++;

        if (targetPoint >= patrolPoints.Length)
        {
            definitionMethod = false;
            DefinitionTargets();
        }
    }


    private void DecreaseTargetInt()
    {
        targetPoint --;

        if (targetPoint <= -1)
        {
            definitionMethod = true;
            DefinitionTargets();
        }

    }




}
