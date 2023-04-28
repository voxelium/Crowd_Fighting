using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{

    [SerializeField] private new Camera camera;

    private void LateUpdate()
    {
        transform.LookAt(camera.transform);
    }
}
