using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*************************************
// vC[ΜμΗ
//*************************************

public class Controller : MonoBehaviour
{
    //OVRManagergp
    OVRInput.Controller rightController, leftController;
    ActionManager actionManager;

    private void Start()
    {
        rightController = OVRInput.Controller.RTouch;
        leftController = OVRInput.Controller.LTouch;

        actionManager = this.GetComponent<ActionManager>();
    }

    private void Update()
    {
        RightControllerDevice();

        LeftControllerDevice();

        
    }

    void RightControllerDevice()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
            // νΜgp
            actionManager.Attack_R();
        }

        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            // νΜπ·
            actionManager.RightChangeWepon();
        }
    }

    void LeftControllerDevice()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
        {
            // νΜgp
            actionManager.Attack_L();
        }

        if (OVRInput.GetDown(OVRInput.RawButton.X))
        {
            // νΜπ·
            actionManager.LeftChangeWepon();
        }
    }
}
