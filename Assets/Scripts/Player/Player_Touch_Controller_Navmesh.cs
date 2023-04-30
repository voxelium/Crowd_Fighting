using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

public class bcp_Player_Touch_Controller1 : MonoBehaviour
{

    [SerializeField] private Vector2 JoystickSize = new Vector2(300, 300);
    [SerializeField] private Float_Joystick Joystick;
    [SerializeField] private NavMeshAgent playerNavMeshAgent;
    [SerializeField] private Animator playerAnimator;

    private Finger MovementFinger;
    private Vector2 JoystickMovementAmount;
    
    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerNavMeshAgent = GetComponent<NavMeshAgent>();
    }


    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
        ETouch.Touch.onFingerDown += HandleFingerDown;
        ETouch.Touch.onFingerUp += HandleLoseFinger;
        ETouch.Touch.onFingerMove += HandleFingerMove;

    }


    private void OnDisable()
    {
        ETouch.Touch.onFingerDown -= HandleFingerDown;
        ETouch.Touch.onFingerUp -= HandleLoseFinger;
        ETouch.Touch.onFingerMove -= HandleFingerMove;
        EnhancedTouchSupport.Disable();
    }


    private void HandleFingerDown(Finger TouchedFinger)
    {
        if (MovementFinger == null && TouchedFinger.screenPosition.y <= Screen.height /2f)
        {
            MovementFinger = TouchedFinger;
            JoystickMovementAmount = Vector2.zero;
            Joystick.gameObject.SetActive(true);

            Joystick.RectTransform.sizeDelta = JoystickSize;
            Joystick.RectTransform.anchoredPosition = ClampStartPosition(TouchedFinger.screenPosition);
        }
    }


    private Vector2 ClampStartPosition(Vector2 StartPosition)
    {
        if (StartPosition.x > Screen.width - JoystickSize.x / 2)
        {
            StartPosition.x = Screen.width - JoystickSize.x / 2;
        }

        if (StartPosition.x < JoystickSize.x / 2)
        {
            StartPosition.x = JoystickSize.x / 2;
        }

        if (StartPosition.y > Screen.height - JoystickSize.x / 2)
        {
            StartPosition.y = Screen.height - JoystickSize.x / 2;
        }

        if (StartPosition.y < JoystickSize.x / 2)
        {
            StartPosition.y = JoystickSize.x / 2;
        }

        return StartPosition;
    }


    private void HandleFingerMove(Finger MovedFinger)
    {
        if (MovedFinger == MovementFinger)
        {
            Vector2 knobPosition;
            float maxMovement = JoystickSize.x / 2.2f;
            ETouch.Touch currentTouch = MovedFinger.currentTouch;

            if (Vector2.Distance(currentTouch.screenPosition,
                Joystick.RectTransform.anchoredPosition) > maxMovement)
            {
                knobPosition = (currentTouch.screenPosition -
                    Joystick.RectTransform.anchoredPosition).normalized * maxMovement;
            }
            else
            {
                knobPosition = currentTouch.screenPosition -
                    Joystick.RectTransform.anchoredPosition;
            }

            Joystick.joystickKnob.anchoredPosition = knobPosition;
            JoystickMovementAmount = knobPosition / maxMovement;
        }
    }



    private void HandleLoseFinger(Finger LostFinger)
    {
        if (LostFinger == MovementFinger)
        {
            MovementFinger = null;
            Joystick.joystickKnob.anchoredPosition = Vector2.zero;
            Joystick.gameObject.SetActive(false);
            JoystickMovementAmount = Vector2.zero;
        }
    }


    private void Update()
    {
        Vector3 direction =
            playerNavMeshAgent.speed * Time.deltaTime * new Vector3(JoystickMovementAmount.x, 0, JoystickMovementAmount.y);

        playerNavMeshAgent.Move(direction);

        playerNavMeshAgent.transform.LookAt(playerNavMeshAgent.transform.position + direction, Vector3.up);


        //print("MovementAmount.x: " + MovementAmount.x);
        //print("MovementAmount.y: " + MovementAmount.y);

        playerAnimator.SetFloat("MoveX", JoystickMovementAmount.x);
        playerAnimator.SetFloat("MoveZ", JoystickMovementAmount.y);



      //временно Удар нажатие на кнопку пробел
        //if (Input.GetButtonDown("Jump"))
        //{
        //    playerAnimator.SetBool("Kick", true);
        //}

    }


}
