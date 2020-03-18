using UnityEngine;
//poner en el pico
public class WaterSpawn : MonoBehaviour
{

    public PoolService waterPool;
    
    // el transform del termo, para leer cuan rotado está
    public Transform termoTransform;
    
    //el prefab de la gota de agua
    public GameObject waterPrefab;

    //el angulo de inclinacion del termo para tirar agua
    public float angleFromUp = 75f;
    
    // el tiempo entre gotas cuando estas cebando
    public float timeBetweenDrops = 0.05f;
    
    //un contador de tiempo
    private float currentTime = 0;

    
    private void Update()
    {
        // la condicion es que el up del termo este muy inclinado respecto del vector up
        var shouldWater = Vector3.Angle(termoTransform.up, Vector3.up) > angleFromUp;
        //si lo está
        if (shouldWater)
        {
            //aumento el contador de tiempo con el tiempo que pasó desde el frame anterior
            currentTime += Time.deltaTime;
            
            // si me pase del tiempo instancio una gota
            if (currentTime > timeBetweenDrops)
            {
                // aca instancio la gota de agua y la ubico en la posicion del pico
                /*TODO: investigar como funcionan los object pool para evitar instanciar/eliminar tantos gameobjects*/
                waterPool.GetPool().Get().transform.position = transform.position;
                //y reseteo el contador de tiempo
                currentTime = 0;
            }

        }
    }


}