using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class LimitRotatingCamera : MonoBehaviour
{
    // public float TouchSensitivity_x = 10f;
    // public float TouchSensitivity_y = 10f;
 
    // // Use this for initialization
    // void Start()
    // {
    //     CinemachineCore.GetInputAxis = this.HandleAxisInputDelegate;
    // }
 
    // private float HandleAxisInputDelegate(string axisName)
    // {
    //     switch (axisName) {
    //         case "Mouse X":
    //             if (Input.touchCount > 0) {
    //                 //Is mobile touch
    //                 return Input.touches[0].deltaPosition.x / TouchSensitivity_x;
    //             } else if (Input.GetMouseButton(0)) {
    //                 // is mouse click
    //                 return Input.GetAxis("Mouse X");
    //             }
    //             break;
    //         case "Mouse Y":
    //             if (Input.touchCount > 0) {
    //                 //Is mobile touch
    //                 return Input.touches[0].deltaPosition.y / TouchSensitivity_y;
    //             } else if (Input.GetMouseButton(0)) {
    //                     // is mouse click
    //                 return Input.GetAxis(axisName);
    //             }
    //             break;
    //         default:
    //             Debug.LogError("Input <" + axisName + "> not recognized.", this);
    //             break;
    //         }
 
    //     return 0f;
    // }
    [SerializeField] private float sensitivityY;
    [SerializeField] private float sensitivityScroll;
    [SerializeField] private float maxZoom = 100;
    [SerializeField] private float minZoom = 20;
    [SerializeField] private float maxYOrbit = 20;
    private CinemachineOrbitalTransposer vcam;
    private float y;
    private float scroll;
   
    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineOrbitalTransposer>();
        scroll = -40;
        y = 10;
    }
    void Update()
    {
       
        y -= + Input.GetAxis("Mouse Y") * sensitivityY;
        y = Mathf.Clamp(y, -maxYOrbit, maxYOrbit);
        vcam.m_FollowOffset.y = y;
       scroll += Input.GetAxis("Mouse ScrollWheel") * sensitivityScroll;
       scroll = Mathf.Clamp(scroll, -maxZoom, -minZoom);
        vcam.m_FollowOffset.x = scroll;
        vcam.m_FollowOffset.z = scroll;
    }
}
