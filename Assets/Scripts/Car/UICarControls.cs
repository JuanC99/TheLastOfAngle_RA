using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UICarControls : MonoBehaviour
{
    public static int Forward = 0;
    public static int Horizontal = 0;

    public static bool Brake = false;
    public static bool Turbo = false;
    public static float Gear = 0;

    [SerializeField] private Slider Slider;
    [SerializeField] private Transform resetPositionTransform;

    private Rigidbody rb;
    private CarController carController;

    private void Start(){
        rb = this.GetComponent<Rigidbody>();
        carController = this.GetComponent<CarController>();
    }

    private void Update(){
        Gear = Slider.value;
    }

    // Foward
    public void OnPointerUpForward(){
        UICarControls.Forward = 0;
    }
    public void OnPointerDownForward(){
        UICarControls.Forward = 1;
    }
  
    // Left
    public void OnPointerUpLeft(){
        UICarControls.Horizontal = 0;
    }
    public void OnPointerDownLeft(){
        UICarControls.Horizontal = -1;
    }
    // Right
    public void OnPointerUpRight(){
        UICarControls.Horizontal = 0;
    }
    public void OnPointerDownRight(){
        UICarControls.Horizontal = 1;
    }
    // Brake
    public void OnPointerUpBrake(){
        UICarControls.Brake = false;
    }
    public void OnPointerDownBrake(){
        UICarControls.Brake = true;
    }
    // Turbo
    public void OnPointerUpTurbo(){
        UICarControls.Turbo = false;
    }
    public void OnPointerDownTurbo(){
        UICarControls.Turbo = true;
    }

    public void OnPointerDownReset(){
        
        this.transform.position = resetPositionTransform.position;
        this.transform.rotation = resetPositionTransform.rotation;

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        foreach (WheelCollider w in carController.wheelsColliders)
        {
            w.motorTorque = 0;
        }
    }
}
