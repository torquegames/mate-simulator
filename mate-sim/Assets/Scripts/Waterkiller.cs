using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterkiller : MonoBehaviour
{

	public PoolService waterPool;

    private void OnTriggerEnter(Collider col)
    {
	    
	    var water = col.GetComponent<BallWater>(); 
	    
    	if(water)
        {
	        waterPool.GetPool().Destroy(water);
    	}
    }
}
