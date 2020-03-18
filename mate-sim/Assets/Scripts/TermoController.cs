using System;
using UnityEngine;

public class TermoController : MonoBehaviour
{

    //velocidad angular hacia abajo
    public float speedDown;
    //velocidad angular hacia arriba
    public float speedUp;
    
    //vector del medio del rango de rotacion
    private Vector3 _midVector;

    //la variacion del vector del medio es 1/16 de vuelta completa
    private float variation = Mathf.PI / 8f;
    
    private void Start()
    {
        //el maximo vector ( el que apunta hacia arriba )  es el promedio entre el left y el up
        var maxVector = Vector3.Slerp(Vector3.up, Vector3.left, 0.5f);
        //el vector minimo es el left
        var minVector = Vector3.left;
        //el vector promedio de los dos (en coordenadas esfericas)
        _midVector = Vector3.Slerp(minVector, maxVector, 0.5f);
    }

    private void Update()
    {
        //si estoy apretando el mouse uso la velocidad angular de cebar
        // sino la velocidad angular de volver el termo a su rotacion original
        var speed = Input.GetMouseButton(0) ? speedDown :  - speedUp;

        //la velocidad angular a aplicar en ese momento
        var deltaAngularVelocity = new Vector3(0,0,speed * Time.deltaTime);
        // con mi velocidad angular genero un cambio de base que representa este cambio, para componer con mi rotacion actual
        var rotationToApply = Quaternion.Euler(deltaAngularVelocity);
        //mi siguiente rotacion va a salir de componer mi rotacion actual con la que representa a la delta velocidad angular actual
        var nextRotation = transform.rotation * rotationToApply;    
        
        // mi siguiente vector UP va a ser convertir el vector (0,1,0) con la siguiente rotacion
        var nextUp = nextRotation * Vector3.up;

        // si el siguiente up no varia mas de la mitad de los grados permitidos del vector intermedio entre los limites
        // y el siguiente up no apunta hacia abajo (el maximo es horizontal) entonces si aplico la rotacion
        if (Vector3.Dot(nextUp, _midVector) > 1 - variation && (nextUp.y > 0))
        {
            transform.rotation = nextRotation;
        }
    }
}