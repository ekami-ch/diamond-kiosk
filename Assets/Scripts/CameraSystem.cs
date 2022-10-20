using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraSystem : MonoBehaviour
{
    public Camera cam;
    public Transform target;
    public float distanceToTarget = 2;
    public float minRotationX = 31;
    private Vector3 previousPosition;

    // public CinemachineVirtualCamera cinemachineVirtualCamera;

    // private Vector3 followOffset;
    // public float followOffsetMin = 1.5f;
    // public float followOffsetMax = 3.5f;

    // public float rotateSpeed = 100f;
    // public float zoomSpeed = 3f;

    private bool dragPanMoveActive;
    private Vector3 lastMousePosition;

    private void Awake() {
        // followOffset = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Zoom Handler Function
        // HandleCameraZoom_MoveForward();
        // Vector3 inputDir = new Vector3(0,0,0);
        // if (Input.GetKey(KeyCode.W)) inputDir.x = +1f;
        // if (Input.GetKey(KeyCode.S)) inputDir.x = -1f;
        // if (Input.GetKey(KeyCode.A)) inputDir.z = -1f;
        // if (Input.GetKey(KeyCode.D)) inputDir.z = +1f;

        // float rotateDir = 0f;
        // float rotateDirY = 0f;
        // if (Input.GetKey(KeyCode.Q)) rotateDir = +1f;
        // if (Input.GetKey(KeyCode.E)) rotateDir = -1f;
        
        // if (Input.GetMouseButtonDown(0)) {
        //     dragPanMoveActive = true;
        //     lastMousePosition = Input.mousePosition;
        // }
        // if (Input.GetMouseButtonUp(0)) {
        //     dragPanMoveActive = false;
        // }
        // if (dragPanMoveActive) {
        //     Vector3 mouseMovemenDelta = Input.mousePosition - lastMousePosition;
        //     Debug.Log(mouseMovemenDelta);
        //     float dragPanSpeed = 0.05f;
        //     // inputDir.x = mouseMovemenDelta.x * dragPanSpeed;
        //     // inputDir.z = mouseMovemenDelta.y * dragPanSpeed;
        //     // if(mouseMovemenDelta.x < 0)
        //     //     rotateDir = +1f;
        //     // if(mouseMovemenDelta.x > 0)
        //     //     rotateDir = -1f;
        //     // if(mouseMovemenDelta.y < 0)
        //     //     rotateDirY = +1f;
        //     // if(mouseMovemenDelta.y > 0)
        //     //     rotateDirY = -1f;

        //     //lastMousePosition = Input.mousePosition;
        // }

        // transform.eulerAngles += new Vector3(0, rotateDir * rotateSpeed * Time.deltaTime, 0);

        // Vector3 moveDir = transform.forward * inputDir.z + transform.right * inputDir.x;

        // float moveSpeed = 10f;
        // transform.position += moveDir * moveSpeed * Time.deltaTime;

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

    // private void HandleCameraZoom_MoveForward() {
    //     Vector3 zoomDir = followOffset.normalized;
    //     Debug.Log(zoomDir);
    //     if (Input.mouseScrollDelta.y > 0) {
    //         followOffset -= zoomDir;
    //     }
    //     if (Input.mouseScrollDelta.y < 0) {
    //         followOffset += zoomDir;
    //     }
    //     if (followOffset.magnitude < followOffsetMin) {
    //         followOffset = zoomDir * followOffsetMin;
    //     }
    //     if (followOffset.magnitude > followOffsetMax) {
    //         followOffset = zoomDir * followOffsetMax;
    //     }
    //     cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = Vector3.Lerp(cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset, followOffset, Time.deltaTime * zoomSpeed);
       
        
    // }
}
