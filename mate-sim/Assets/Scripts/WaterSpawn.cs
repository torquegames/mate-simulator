using UnityEngine;
//poner en el pico
public class WaterSpawn : MonoBehaviour
{
    public Transform termoTransform;
    public GameObject waterPrefab;

    public float timeBetweenDrops = 0.05f;
    
    private float currentTime = 0;

    private float angleFromUp = 75f;    
    
    private void Update()
    {
        var shouldWater = Vector3.Angle(termoTransform.up, Vector3.up) > angleFromUp; 
        if (shouldWater)
        {
            currentTime += Time.deltaTime;

            if (currentTime > timeBetweenDrops)
            {
                Instantiate(waterPrefab, transform.position, transform.rotation);
                currentTime = 0;
            }

        }
    }


}