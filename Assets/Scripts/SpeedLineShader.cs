using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedLineShader : MonoBehaviour
{
    

    void Start()
    {
        
    }

    void Update()
    {
        Shader.SetGlobalFloat("_ZWrite", 0);
    }
}
