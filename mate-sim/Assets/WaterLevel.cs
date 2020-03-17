using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLevel : MonoBehaviour
{
    
    public float yDistance;
        double yLevel;

        private void Start()
        {
            yLevel = yDistance + transform.position.y;
            work = true;
            GetComponent<Collider>().isTrigger = true;
        }

        private bool work = true;
        
        private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BallWater>() )
        {
            if(transform.position.y < yLevel)
            {
                transform.position += 0.01f * other.transform.localScale.x * Vector3.up;

                Destroy(other.gameObject);
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


        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawCube(transform.position +Vector3.up * yDistance, new Vector3(.1f,0.01f,.1f));
            
        }
}
