using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureOffset : MonoBehaviour
{
    // unity me permite generar un entero para identificar una variable de un material por su nombre
    private static readonly int BaseMap = Shader.PropertyToID("_BaseMap");
    
    //el material que quiero modificar
    public Material mat;

    //la velocidad con la que voy a mover los UV
    public float speed = -10;

    private void Update()
    {
        // agarro el offset de mi textura
        var last = mat.GetTextureOffset(BaseMap);
        //lo muevo en Y mi velocidad * deltatime
        last.y += Time.deltaTime * speed;
        //aplico el nuevo vector offset a mi textura
        mat.SetTextureOffset(BaseMap,last);
    }
}
