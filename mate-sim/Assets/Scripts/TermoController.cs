using System;
using UnityEngine;

public class TermoController : MonoBehaviour
{

    public float speedDown;
    public float speedUp;

    private Vector3 maxVector;
    private Vector3 minVector;
    private Vector3 midVector;

    private float variation = Mathf.PI / 8f;
    
    private void Start()
    {
        maxVector = Vector3.Slerp(Vector3.up, Vector3.right * -1, 0.5f);
        minVector = transform.right * -1f;
        midVector = Vector3.Slerp(minVector, maxVector, 0.5f);
    }

    private bool moving = false;    
    
    
    void Update()
    {

        moving = Input.GetMouseButton(0);

        var speed = moving ? speedDown :  - speedUp;
        Quaternion nextRotation = transform.rotation * 
                                  Quaternion.Euler(0,0,speed * Time.deltaTime);

        var nextUp = nextRotation * Vector3.up;
        if(Vector3.Dot(nextUp, midVector) < 1 - variation) return;
        if (nextUp.y < 0) return;

        transform.rotation = nextRotation;
        
        

    }
        
}