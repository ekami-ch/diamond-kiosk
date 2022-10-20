using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
public class Zoom : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public CinemachineComponentBase cinemachineComponentBase;
    public float cameraDistance = 1f;
    public float zoomSensibility = 0.2f;
    public float maxZoom = 23f;
    public float minZoom = 3f;
    public Slider zoomSlider;
    private float oldSliderValue = 35; 

    public float zoomOffset = 0f; // Above 0 if there is a value difference between slider and zoom value
    // Start is called before the first frame update
    void Start()
    {
        oldSliderValue = 1;
        zoomSlider.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (cinemachineComponentBase == null) {
            cinemachineComponentBase = virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
        }
        if (Input.GetAxis("Mouse ScrollWheel") != 0) {
            cameraDistance = Input.GetAxis("Mouse ScrollWheel");
            if (cinemachineComponentBase is CinemachineFramingTransposer) {
                if(zoomSlider.value - cameraDistance * 10 > maxZoom) {
                    (cinemachineComponentBase as CinemachineFramingTransposer).m_CameraDistance -= 0;
                    zoomSlider.value = maxZoom;
                }
                else if (zoomSlider.value - cameraDistance * 10 < minZoom) {
                    (cinemachineComponentBase as CinemachineFramingTransposer).m_CameraDistance -= 0;
                    zoomSlider.value = minZoom;
                }
                else {
                    (cinemachineComponentBase as CinemachineFramingTransposer).m_CameraDistance -= cameraDistance * zoomSensibility;
                    zoomSlider.value -= cameraDistance * 10;
                }
                oldSliderValue = zoomSlider.value;
                Debug.Log("Slider : " + (zoomSlider.value - cameraDistance * 10));
                Debug.Log("cameraDistance : " + (cinemachineComponentBase as CinemachineFramingTransposer).m_CameraDistance);
            }
        }
        else {
            cameraDistance = (zoomSlider.value + zoomOffset )/10;
            if (cinemachineComponentBase is CinemachineFramingTransposer) {
                if(zoomSlider.value > maxZoom) {
                    zoomSlider.value = maxZoom;
                }
                else if (zoomSlider.value < minZoom) {
                    zoomSlider.value = minZoom;
                }
                else {
                    (cinemachineComponentBase as CinemachineFramingTransposer).m_CameraDistance = cameraDistance;
                }
                oldSliderValue = zoomSlider.value;
                Debug.Log("Slider : " + (zoomSlider.value));
                Debug.Log("cameraDistance : " + (cinemachineComponentBase as CinemachineFramingTransposer).m_CameraDistance);
            }
        }
        // Code for the slider change
        // if (zoomSlider.value > oldSliderValue) {
        //     (cinemachineComponentBase as CinemachineFramingTransposer).m_CameraDistance -= 0.1f;
        // }
        // if (zoomSlider.value < oldSliderValue) {
        //     (cinemachineComponentBase as CinemachineFramingTransposer).m_CameraDistance += 0.1f;
        // }
        // oldSliderValue = (cinemachineComponentBase as CinemachineFramingTransposer).m_CameraDistance *10;
    }
}
