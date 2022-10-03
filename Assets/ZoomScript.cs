using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
public class ZoomScript : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachineVirtualCamera;
    public float zoomSpeed = 3f;
    private Vector3 followOffset;
    public float followOffsetMin = 1.5f;
    public float followOffsetMax = 3.5f;

    private float oldSliderValue = 35; 

    public Slider zoomSlider;
    private Vector3 zoomDir;

    private void Awake() {
        followOffset = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        zoomDir = followOffset.normalized;
        controlZoom();
        //zoomSlider.onValueChanged.AddListener(delegate { controlZoom(zoomSlider.value); });

        
    }

    private void controlZoom() {
        // Code for mouse scoll zoom
        // If scroll bottom
        if (Input.mouseScrollDelta.y > 0) {
            followOffset -= zoomDir/10;
            zoomSlider.value += 2.3f;
            oldSliderValue = zoomSlider.value;
        }
        // If scroll up
        if (Input.mouseScrollDelta.y < 0) {
            followOffset += zoomDir/10;
            zoomSlider.value -= 2.3f;
            oldSliderValue = zoomSlider.value;
        }
        // Code for the slider change
        if (zoomSlider.value > oldSliderValue) {
            followOffset -= (zoomDir/30) * ( zoomSlider.value - oldSliderValue );
        }
        if (zoomSlider.value < oldSliderValue) {
            followOffset += (zoomDir/30) * - ( zoomSlider.value - oldSliderValue );
        }
        // Check the min/max zoom
        if (followOffset.magnitude < followOffsetMin) {
            followOffset = zoomDir * followOffsetMin;
        }
        if (followOffset.magnitude > followOffsetMax) {
            followOffset = zoomDir * followOffsetMax;
        }
        cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = Vector3.Lerp(cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset, followOffset, Time.deltaTime * zoomSpeed);
        oldSliderValue = zoomSlider.value;
    }
}
