using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMove : MonoBehaviour
{
    public Material mat;

    public float speed = 1;
    
    private void OnValidate()
    {
        print(string.Join("; ",mat.GetTexturePropertyNames()));
    }

    private void Update()
    {
        var last = mat.GetTextureOffset("_BaseMap"); 
        mat.SetTextureOffset("_BaseMap",last + Vector2.up * Time.deltaTime * speed);
    }
}
