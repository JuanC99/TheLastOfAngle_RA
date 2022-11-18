using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCamara : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            float desplazamientoX = Input.GetAxisRaw("Mouse X");
            float desplazamientoY = Input.GetAxisRaw("Mouse Y");

            transform.Translate(new Vector3(desplazamientoX, 0 , desplazamientoY));
    }
}
