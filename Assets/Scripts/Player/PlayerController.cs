using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Animator animator;
    private Rigidbody Rigidbody;

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        Vector3 directionVector = new Vector3(0, 0, 1);

        animator.SetFloat("BlendSpeed", Vector3.ClampMagnitude(directionVector, 1).magnitude);
        Rigidbody.velocity = Vector3.ClampMagnitude(directionVector, 1) * speed;


    }

}
