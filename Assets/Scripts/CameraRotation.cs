using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CameraRotation : MonoBehaviour
{
    public Camera cam;
    public Transform target;
    public float distanceToTarget = 2;
    public float minRotationX = 31;
    private Vector3 previousPosition;

    // Activate or not Zoom with FOV, take the Distance zoom otherwise
    public bool fovZoom = false;

    // Zoom Slider
    public Slider zoomSlider;

    // Fov Zoom Settings
    public float minFovZoom = 1.0f;
    public float maxFovZoom = 90.0f;
    public float scrollSensitivity = 20.0f;

    // Distance Zoom Settings
    public Transform parentObject;
    public float zoomLevel;
    public float sensitivity=100f;
    public float speed = 1000;
    public float maxZoom = 100;
    public float zoomPosition;

    // Clipping Settings
    public GameObject[] clippingTargetList;

    private float fov;

    void Start() {
        if(fovZoom) {
            zoomSlider.minValue = minFovZoom;
            zoomSlider.maxValue = maxFovZoom;
        }
        else {
            zoomSlider.minValue = 0;
            zoomSlider.maxValue = maxZoom * 10;
            zoomSlider.value = 0;
        }
        
    }
 

    void Update()
    {
        // FOV Zoom method
        if(fovZoom) {
            fov = cam.fieldOfView;
            fov -= Input.GetAxis("Mouse ScrollWheel") * scrollSensitivity;
            fov = Mathf.Clamp(fov, minFovZoom, maxFovZoom);
            zoomSlider.value = 0 + fov;
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, fov, Time.deltaTime);
        }
        // Distance Zoom
        else {
            // If scrollwheel is used, set the zoom level based on the scroll delta y
            if(Input.GetAxis("Mouse ScrollWheel") != 0) {
                zoomLevel += Input.mouseScrollDelta.y * sensitivity;
                zoomLevel = Mathf.Clamp(zoomLevel, 0, maxZoom);
            }
            // Else use the slider value to define the zoom Level
            else 
            {
                zoomLevel = zoomSlider.value / 10;
            }
            zoomPosition = Mathf.MoveTowards(zoomPosition, zoomLevel, speed * Time.deltaTime);
            transform.position = parentObject.position + (transform.forward * zoomPosition);
            zoomSlider.value = zoomLevel * 10;
        }
        
        // If Left Mouse button, previous position takes the mouse
        if (Input.GetMouseButtonDown(0))
        {
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 newPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            Vector3 direction = previousPosition - newPosition;
            
            float rotationAroundYAxis = -direction.x * 180; // camera moves horizontally
            float rotationAroundXAxis = direction.y * 180; // camera moves vertically
            
            parentObject.transform.position = target.position;

            parentObject.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);

            parentObject.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World); // <— This is what makes it work!
            
            parentObject.transform.Translate(new Vector3(0, 0, -distanceToTarget));

            previousPosition = newPosition;
        }

        if(cam.transform.eulerAngles.x < minRotationX) {
                //cam.transform.Rotate(new Vector3(1, 0, 0), -rotationAroundXAxis);
                cam.transform.rotation = Quaternion.Euler(31,cam.transform.eulerAngles.y , cam.transform.eulerAngles.z);
        }

        // foreach(GameObject object in clippingTargetList)
        // {
        //     if()
        // }
    }
}
