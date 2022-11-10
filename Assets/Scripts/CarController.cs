using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentBreakForce;
    private bool isBreaking;
    private bool turboActivated;
    private float currentGear;

    private Vector3 centerOfMass  = new Vector3(0,0,0);
    [SerializeField] private float speed = 0.0f;


    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle = 30;
    [SerializeField] private float turboMultiplier = 5f;
    [SerializeField] private int maxSpeed = 40;
    
    // Ruedas Colliders
    public List<WheelCollider> wheelsColliders;

    // Ruedas Transforms
    [SerializeField] private List<Transform> wheelsTransforms;

    private Rigidbody rb;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass;
    }

    private void FixedUpdate() {
        GetInput();
        ApplyBreaking();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
        speed = transform.InverseTransformDirection(rb.velocity).z * 3.6f;

    }
   
    private void HandleMotor(){
        foreach (WheelCollider w in wheelsColliders)
        {
            var currentMaxSpeed = turboActivated ? maxSpeed + 15 : maxSpeed;
            
            if((Mathf.Abs(speed) < currentMaxSpeed)){

                if(turboActivated){
                    w.motorTorque = verticalInput * (motorForce * turboMultiplier);
                }else{
                    w.motorTorque = verticalInput * motorForce;
                }
            }else{
                w.motorTorque = -motorForce * 3;
            }
            // Si el turbo esta activado aplica fuerza del turbo si no no;
        }
        currentBreakForce = isBreaking ? breakForce : 0f;
    }

    private void ApplyBreaking(){
        foreach (WheelCollider w in wheelsColliders)
        {
            w.motorTorque = -motorForce*10;
            w.brakeTorque = currentBreakForce;
        }
    }
    private void HandleSteering(){
        currentSteerAngle = maxSteerAngle * horizontalInput;
        wheelsColliders[0].steerAngle = currentSteerAngle; // rueda delantera derecha
        wheelsColliders[5].steerAngle = currentSteerAngle; // rueda delantera izquierda
    }

    private void GetInput(){
        horizontalInput =  PlayerInputs.HorizontalInput;
        verticalInput = PlayerInputs.VerticalInput;
        isBreaking = PlayerInputs.IsBreaking;
        turboActivated =  PlayerInputs.TurboActivated;
        currentGear = PlayerInputs.Gear;

        if(currentGear == 0){
            verticalInput = PlayerInputs.VerticalInput * -1;
        }else if(currentGear == 1){
            verticalInput = PlayerInputs.VerticalInput;
        }
    }
    private void UpdateWheels(){
        for (int index = 0; index < wheelsColliders.Count; index++)
        {
            UpdateSingleWheel(wheelsColliders[index], wheelsTransforms[index]);
        }
    }

    private void UpdateSingleWheel(WheelCollider wCollider, Transform wTransform){
        Vector3 pos;
        Quaternion rot;

        wCollider.GetWorldPose(out pos, out rot);
        wTransform.SetPositionAndRotation(pos, new Quaternion(rot.x, rot.y, rot.z ,rot.w));
    }
}
