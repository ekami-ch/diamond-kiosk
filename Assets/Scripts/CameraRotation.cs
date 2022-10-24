using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.WSA.Input;
//using UnityEngine.InputSystem;
public class CameraRotation : MonoBehaviour
{
    // Camera
    public Camera cam;
    // Camera's Target
    public Transform target;
    // Distance to the target
    public float distanceToTarget = 2;
    public float minRotationX = 31;

    
    // Allow Camera Movement
    public bool moveAllowed = true;

    // Zoom Slider
    public Slider zoomSlider;

    // Distance Zoom Settings
    public Transform parentObject; // Camera Parent Object
    public float zoomLevel;
    public float sensitivity = 0.1f;
    public float speed = 5f;
    public float maxZoom = 2f;
    public float zoomPosition;

    // Private 
    //private TouchControls controls; // New Unity Input System Touch Controls
    private Vector3 previousPosition; // Previous Camera's parent object position
    // private Coroutine cameraCoroutine;
    // private Coroutine previousPositionCoroutine;

    // private InputAction leftMouseHold;
    // private InputAction leftMouseClick;

    void Awake() {
        // Instantiate Touch Controls
        //controls = new TouchControls();
    }
    void Start() {
        // Set the default values for the zoom Slider
        zoomSlider.minValue = 0; 
        zoomSlider.maxValue = maxZoom * 10;
        zoomSlider.value = 0;

        // controls.Pointer.MouseLeftClick.started += _ => CameraRotateStart();
        // controls.Pointer.MouseLeftClick.canceled += _ => CameraRotateEnd();
        // controls.Pointer.MouseLeftClick.started += _ => PreviousPositionStart();
        // controls.Pointer.MouseLeftClick.canceled += _ => PreviousPositionEnd();
    }
    
    void Update()
    {
        CameraZoom();
        cameraRotate();
    }

    // private void CameraRotateStart() {
    //     cameraCoroutine = StartCoroutine(cameraRotate());
    // }
    // private void CameraRotateEnd() {
    //     StopCoroutine(cameraRotate());
    // }
    // private void PreviousPositionStart() {
    //     previousPositionCoroutine = StartCoroutine(setPreviousPosition());
    // }
    // private void PreviousPositionEnd() {
    //     StopCoroutine(setPreviousPosition());
    // }

    private void setPreviousPosition() {
        previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
    }

    private void cameraRotate() {
        // If movement is allowed
        if(moveAllowed) {
            /* ----------------------- MOVEMENT ----------------------- */
            // if(Input.touchCount == 2 && (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved)) {
            //     Touch touchZero = Input.GetTouch(0);
            //     Touch touchOne = Input.GetTouch(1);
            //     Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            //     Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            //     float prevMagnitude = ( touchZeroPrevPos - touchOnePrevPos ).magnitude;
            //     float currentMagnitude = ( touchZero.position - touchOne.position).magnitude;

            //     float difference = currentMagnitude - prevMagnitude;

            //     zoomSlider.value -= difference * 0.01f;
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
        }
        /* --------------------- END MOVEMENT --------------------- */
    }
    private void CameraZoom() {
        /* --------------------- ZOOM --------------------- */
        // Distance Zoom
        // If scrollwheel is used, set the zoom level based on the scroll delta y
        if(Input.GetAxis("Mouse ScrollWheel") != 0) {
            zoomLevel += Input.mouseScrollDelta.y * sensitivity;
            zoomLevel = Mathf.Clamp(zoomLevel, 0, maxZoom);
        }
        // Else use the slider value to define the zoom Level
        else {
            zoomLevel = zoomSlider.value / 10;
        }

        zoomPosition = Mathf.MoveTowards(zoomPosition, zoomLevel, speed * Time.deltaTime);
        // Camera Parent is moved according to Zoom
        transform.position = parentObject.position + (transform.forward * zoomPosition);
        // ZoomLevel is 10 times less than the value in slider, we multiply it to 10 to make it normal on slider ONLY
        zoomSlider.value = zoomLevel * 10;
        /* ------------------- END ZOOM -------------------- */
    }

    public void setMoveAllowed(bool statut) {
        moveAllowed = statut;
    }

    void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Renderer>().enabled = false;
    }
    void OnCollisionExit(Collision collision)
    {
        collision.gameObject.GetComponent<Renderer>().enabled = true;
    }
}
