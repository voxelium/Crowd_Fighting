using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoot : MonoBehaviour
{
    [SerializeField] private float enemyRootRotate = 120f;


    public void SetRootRotate()
    {
        transform.Rotate(0, enemyRootRotate, 0, Space.Self);
        Debug.Log("Враг повернут на:" + enemyRootRotate);
    }

    public void SetUnRotate()
    {
        transform.Rotate(0, enemyRootRotate * -1f, 0, Space.Self);
        Debug.Log("Враг повернут обратно");
    }


}
