using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameMode : MonoBehaviour
{
    public event UnityAction EventGameWin;
    private GameObject[] enemy;
    private int enemyCount;

    private void Start()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = enemy.Length;
    }


    public void EnemyCountDecrease()
    {
        enemyCount --;

        if (enemyCount <= 0)
        {
            EventGameWin?.Invoke();
        }
    }

}
