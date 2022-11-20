using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPostProcessing : MonoBehaviour
{
    public Material material;
    public GameObject target;

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {

        material.SetVector("_Origin", new Vector4(target.transform.position.x, target.transform.position.y, target.transform.position.z, 0));
        Graphics.Blit(source, destination, material);



    }

}

