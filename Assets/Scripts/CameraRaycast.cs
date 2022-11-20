using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{

    [SerializeField] Transform mark;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray camRay = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(camRay, out RaycastHit hit))
        {
            mark.position = new Vector3(hit.point.x, hit.point.y , hit.point.z);
        }
    }
}
