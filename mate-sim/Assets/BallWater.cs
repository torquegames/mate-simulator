using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallWater : MonoBehaviour
{
    public float maxSpeed = 0.1f;

    private Rigidbody body;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (maxSpeed * maxSpeed < body.velocity.sqrMagnitude)
        {
            body.velocity = body.velocity.normalized * maxSpeed;
        }
    }
}
