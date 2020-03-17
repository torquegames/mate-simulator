using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookController : MonoBehaviour
{
    private Vector3 initialForward;
    private Vector3 initialLeft;
    [SerializeField] 
    private float speed = 30;

    private float rotSpeed = 0;
    
    
    private void Start()
    {
        initialForward = transform.rotation * Vector3.forward;
        initialLeft = transform.rotation * Vector3.left;
    }

    void Update()
    {
        const string axisName = "Horizontal";
        rotSpeed = Input.GetAxis(axisName);

        var nextRotation = 
            transform.rotation * Quaternion.Euler(0, rotSpeed * speed * Time.deltaTime, 0);

        var nextForward = nextRotation * Vector3.forward;
        
        if (Vector3.Dot(nextForward, initialForward) < 0) return;
        if (Vector3.Dot(nextForward, initialLeft) < 0) return;
        if (Mathf.Abs(nextForward.y) > 0.1f) return;

        transform.rotation = nextRotation;
    }
}
