using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, iDamageable
{
    public bool ApplyDamage(Rigidbody rigidbody, float force)
    {
        Debug.Log("я коробка");
        return true;
    }
}
