using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KillArea : MonoBehaviour
{
    public event UnityAction EventGameOver;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(other.gameObject);
            EventGameOver?.Invoke();
        }

        if (other)
        {
            Destroy(other.gameObject);
        }


    }
}
