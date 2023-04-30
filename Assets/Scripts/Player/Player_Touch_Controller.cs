using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

public class Player_Touch_Controller : MonoBehaviour
{

    [SerializeField] private Vector2 JoystickSize = new Vector2(300, 300);
    [SerializeField] private Float_Joystick Joystick;
    [SerializeField] private Player_Move_Controller movementController;
    [SerializeField] private Animator playerAnimator;

    private Finger MovementFinger;
    private Vector2 JoystickMovementAmount;
    
    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
        movementController = GetComponent<Player_Move_Controller>();
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

            //Debug.Log("Touch: " + TouchedFinger.screenPosition);
            //Debug.Log("Joystick: " + Joystick.RectTransform.anchoredPosition);
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
        Vector3 joystickDirection = new Vector3(JoystickMovementAmount.x, 0, JoystickMovementAmount.y);
        movementController.direction = joystickDirection;
        movementController.transform.LookAt(movementController.transform.position + joystickDirection, Vector3.up);

        playerAnimator.SetFloat("MoveX", JoystickMovementAmount.x);
        playerAnimator.SetFloat("MoveZ", JoystickMovementAmount.y);

    }

}
