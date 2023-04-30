using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
[DisallowMultipleComponent]

public class Float_Joystick : MonoBehaviour
{
    public RectTransform joystickKnob;
    public RectTransform RectTransform;
    

    private void Awake()
    {
        RectTransform = GetComponent<RectTransform>();
    }

}
