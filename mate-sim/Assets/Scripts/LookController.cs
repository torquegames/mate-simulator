using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//este script hace girar la camara
public class LookController : MonoBehaviour
{
    
    // la velocidad angular con la que quiero rotar
    [SerializeField] private float speed ;

    //el nombre del axis (en unity)
    private const string ArrowsAndADAXisName = "Horizontal";
    
    private void Update()
    {
        var rotationDirection = Input.GetAxis(ArrowsAndADAXisName);
        
        // la siguiente matriz de rotacion que quiero aplicar a la camara
        Quaternion nextRotation;
        
        // la velocidad angular en ese momento
        // (esta multiplicado por el delta Time para tener la compensacion por los fps,
        // o algo asi me explicó un amigo )
        Vector3 deltaAngularVelocity = new Vector3(0, rotationDirection * speed * Time.deltaTime, 0);
        
        //con la rotacion que quiero aplicar en ese momento genero un cambio de base para componerlo con el actual
        var quaternion = Quaternion.Euler(deltaAngularVelocity);
        
        // compongo el cambio de base actual con la rotacion que quiero aplicar
        nextRotation = transform.rotation * quaternion;
        
        // en ese cambio de base transformo el vector forward para saber cual va a ser el forward si aplico esta rotacion
        var nextForward = nextRotation * Vector3.forward;
        
        /*
         *  como la rotacion del player es identity, el (0,0,1) es el forward del player, el (1,0,0) su right y el (0,1,0) su up 
         */
        
        // si el forward no se fue a mas de 90 grados del forward inicial
        if (Vector3.Dot(nextForward, Vector3.forward) > 0  
        // si el forward no se va a mas de 90 grados del left inicial (la direccion hacia el conductor)    
        && Vector3.Dot(nextForward, Vector3.left) > 0
        //si la altura del forward en Y va a ser menor a 0.1 (si no se le inclino mucho arriba/abajo la cabeza al cebador)
        && Mathf.Abs(nextForward.y) < 0.1f)
        {
            //finalmente si se dan las condiciones asigno el nuevo cambio de base a mi rotacion actual
            transform.rotation = nextRotation;
        }
    }
}
