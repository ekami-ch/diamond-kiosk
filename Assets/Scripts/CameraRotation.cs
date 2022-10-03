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

    //public bool fovZoom = false;

    public Slider zoomSlider;
    public float minFovZoom = 1.0f;
    public float maxFovZoom = 90.0f;
    public float scrollSensitivity = 20.0f;

    private float fov;

    void Start() {
        zoomSlider.minValue = minFovZoom;
        zoomSlider.maxValue = maxFovZoom;
    }
 

    void Update()
    {
        // FOV Zoom method
        //if(fovZoom) {
        fov = cam.fieldOfView;
        fov -= Input.GetAxis("Mouse ScrollWheel") * scrollSensitivity;
        fov = Mathf.Clamp(fov, minFovZoom, maxFovZoom);
        zoomSlider.value = 0 + fov;
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, fov, Time.deltaTime);
        //}
        // else {
        //     if (Input.GetAxis("Mouse ScrollWheel") > 0) {
        //         cam.transform.position = new Vector3(transform.position.x, transform.position.y-.6f, transform.position.z+.2f);
        //         //transform.Rotate(-1, 0, 0);
        //     }
        //     if (Input.GetAxis("Mouse ScrollWheel") < 0) {
        //         cam.transform.position = new Vector3(transform.position.x, transform.position.y+.6f, transform.position.z-.2f);
        //         //transform.Rotate(1, 0, 0);
        //     }
        // }

        // float scrollAxis = Input.GetAxis ("Mouse ScrollWheel");
        // if ( Input.GetAxis("Mouse ScrollWheel") > 0) {     
        //     cam.transform.Translate(Vector3.forward * Time.deltaTime * 10000f * scrollAxis, Space.Self );
        // }

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
            
            cam.transform.position = target.position;

            cam.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);

            cam.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World); // <— This is what makes it work!
            
            cam.transform.Translate(new Vector3(0, 0, -distanceToTarget));

            previousPosition = newPosition;
        }

        if(cam.transform.eulerAngles.x < minRotationX) {
                //cam.transform.Rotate(new Vector3(1, 0, 0), -rotationAroundXAxis);
                cam.transform.rotation = Quaternion.Euler(31,cam.transform.eulerAngles.y , cam.transform.eulerAngles.z);
        }
    }
}
