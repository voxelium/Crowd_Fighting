using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//[RequireComponent(typeof(NavMeshAgent))]

public class test_EnemyController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;

    private void Start()
    {
        //agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray movePorition = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(movePorition, out var hitInfo))
            {
                agent.SetDestination(hitInfo.point);
            }
        }
    }

}
