using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCarCamera : MonoBehaviour
{

    public Transform target;


    // Update is called once per frame
    void Update()
    {
        this.transform.position = target.position;
    }
}
