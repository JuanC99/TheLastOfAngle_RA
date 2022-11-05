using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  PlayerInputs : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    public static float HorizontalInput;
    public static float VerticalInput;
    public static bool IsBreaking;
    public static bool TurboActivated;
    
    public static float Gear;

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void GetInput(){
        HorizontalInput =  Input.GetAxis(HORIZONTAL) != 0 ? Input.GetAxis(HORIZONTAL) :  UICarControls.Horizontal;
        VerticalInput = Input.GetAxis(VERTICAL) != 0 ? Input.GetAxis(VERTICAL) :  UICarControls.Forward;
        IsBreaking = Input.GetKey(KeyCode.Space) != false ? Input.GetKey(KeyCode.Space) : UICarControls.Brake ;
        TurboActivated =  Input.GetKey(KeyCode.LeftShift) != false ? Input.GetKey(KeyCode.LeftShift) : UICarControls.Turbo;
        Gear = UICarControls.Gear;
    }
}
