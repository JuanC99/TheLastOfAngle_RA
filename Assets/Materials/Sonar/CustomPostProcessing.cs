using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPostProcessing : MonoBehaviour
{
    public Material material;
    public GameObject test;

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {

        material.SetVector("_Origin", new Vector4(test.transform.position.x, test.transform.position.y, test.transform.position.z, 0));

        Graphics.Blit(source, destination, material);



    }

}

