using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillArea : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        
        if (other)
        {
            Destroy(other.gameObject);
        }


    }
}
