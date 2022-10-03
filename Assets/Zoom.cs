using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Zoom : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public CinemachineComponentBase cinemachineComponentBase;
    public float cameraDistance = 1f;
    public float zoomSensibility = 0.2f;
    public float maxZoom = 100f;
    public float minZoom = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cinemachineComponentBase == null) {
            cinemachineComponentBase = virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
        }
        if (Input.GetAxis("Mouse ScrollWheel") != 0) {
            cameraDistance = Input.GetAxis("Mouse ScrollWheel");
            if(cinemachineComponentBase is CinemachineFramingTransposer) {
                // if(cameraDistance > maxZoom)
                //     (cinemachineComponentBase as CinemachineFramingTransposer).m_CameraDistance = maxZoom;
                // else 
                    (cinemachineComponentBase as CinemachineFramingTransposer).m_CameraDistance -= cameraDistance * zoomSensibility;
            }
        }
        // if (Input.GetAxis("Mouse ScrollWheel") < 0) {
        //     cameraDistance = Input.GetAxis("Mouse ScrollWheel") * zoomSensibility;
        //     if(cinemachineComponentBase is CinemachineFramingTransposer) {
        //         if(cameraDistance < minZoom)
        //             (cinemachineComponentBase as CinemachineFramingTransposer).m_CameraDistance = minZoom;
        //         else 
        //             (cinemachineComponentBase as CinemachineFramingTransposer).m_CameraDistance += cameraDistance;
        //     }
        // }
    }
}
