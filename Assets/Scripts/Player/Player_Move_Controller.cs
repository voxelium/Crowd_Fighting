using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class Player_Move_Controller : MonoBehaviour
{
    private CharacterController characterController;
 
    [Header("Movement")]
    [SerializeField] private float speed = 4.0f;
    private Vector2 _input;
    public Vector3 direction;

    [Header("Gravity")]
    [SerializeField] private float gravityMultiplier = 1.0f;
    private float gravity = -9.81f;
    private float velocity;

    [Header("Jump")]
    [SerializeField] private float jumpPower = 3.5f;
    [SerializeField] private int maxNumberOfJumps = 1;
    private int numberOfJumps;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        GravityCharacter();
        MoveCharacter();
    }

    private void GravityCharacter()
    {
        if (IsGrounded() && velocity < 0)
        {
           velocity = -0.5f;
        }
        else
        {
           velocity += gravity * gravityMultiplier * Time.deltaTime;
        }

        direction.y = velocity;
    }


    private void MoveCharacter()
    {
        characterController.Move(direction * speed * Time.deltaTime);
    }


    public void Move(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
        direction = new Vector3(_input.x, 0, _input.y);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        if (!IsGrounded() && numberOfJumps >= maxNumberOfJumps) return;

        if (numberOfJumps == 0) StartCoroutine(WaitForLanding());

        numberOfJumps++;

        velocity = jumpPower;

        //каждый следующий прыжок в воздухе будет меньше предыдущего
        //velocity = jumpPower / numberOfJumps;
    }

    private bool IsGrounded() => characterController.isGrounded;

    //перед тем как сбросить число прыжков в ноль
    //сначала подождет пока персонаж будет в воздухе,
    //потом, когда снова упадет на землю
    private IEnumerator WaitForLanding()
    {
        yield return new WaitUntil(() => !IsGrounded());
        yield return new WaitUntil(IsGrounded);
        numberOfJumps = 0;
    }

}
