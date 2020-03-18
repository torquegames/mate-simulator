using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLevel : MonoBehaviour
{

    public float speed = 0.1f;
    public float yDistance;
    double yLevel;

    public PoolService waterPool;

    private void Start()
    {
        yLevel = yDistance + transform.position.y;
        work = true;
        GetComponent<Collider>().isTrigger = true;
    }

    private bool work = true;
        
    private void OnTriggerEnter(Collider other)
    {
        BallWater water = other.GetComponent<BallWater>(); 
        if(water)
        {
        
            if(transform.position.y < yLevel)
            {
                transform.position += other.transform.localScale.x * speed * Vector3.up;
     
                waterPool.GetPool().Destroy(water);
            }
            else
            {
                if (work)
                {
                    GetComponent<Collider>().isTrigger = false;
                }
                work = false;
            }
        }
    }
}