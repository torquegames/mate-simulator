using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallWater : MonoBehaviour, IPooleable
{
    public float maxSpeed = 0.1f;

    private Rigidbody body;
    private bool _isPooled;
    private Vector3 firstScale;
    
    
    private void Awake()
    {
        firstScale = transform.localScale;
        body = GetComponent<Rigidbody>();
    }

    private void OnSpawn()
    {
        transform.localScale = firstScale + Random.value * 0.02f * Vector3.one;
    }

    private void Update()
    {
        if (maxSpeed * maxSpeed < body.velocity.sqrMagnitude)
        {
            body.velocity = body.velocity.normalized * maxSpeed;
        }
    }

    public Guid Guid { get; set; }

    public bool IsPooled
    {
        get => _isPooled;
        set //Si le asigno true, significa que lo quería eliminar del juego y traerlo a la pool, por lo tanto, lo desactivo. Viceversa
        {
            _isPooled = value;
            gameObject.SetActive(!_isPooled);
            if (!_isPooled)
            {
                OnSpawn();
            }
        }
    }
}
