using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinchDetection : MonoBehaviour
{
    private TouchControls controls;
    private Coroutine pinchCoroutine;

    public Slider zoomSlider;

    private void Awake() {
        controls = new TouchControls();
    }
    // Start is called before the first frame update
    void Start()
    {
        controls.Touch.SecondaryTouchContact.started += _ => PinchStart();
        controls.Touch.SecondaryTouchContact.canceled += _ => PinchEnd();
        controls.Touch.PrimaryTouchContact.canceled += _ => PinchEnd();
    }

    private void PinchStart() {
        pinchCoroutine = StartCoroutine(PinchFingerDetection());
    }

    private void PinchEnd() {
        StopCoroutine(PinchFingerDetection());
    }


    // private void OnEnable() {
    //     controls.Enable();
    // }

    // private void OnDisable() {
    //     controls.Disable();
    // }

    IEnumerator PinchFingerDetection() {
        float previousDistance = 0f, distance = 0f;
        while(true) {
            distance = Vector2.Distance(controls.Touch.PrimaryFingerPosition.ReadValue<Vector2>(),
                       controls.Touch.SecondaryFingerPosition.ReadValue<Vector2>());
            // Detection
            // Zoom out
            if(distance > previousDistance) {
                zoomSlider.value++;
            }
            // Zoom in
            else if (distance < previousDistance ) {
                zoomSlider.value--;
            }
            // Keep track of previous distance for next loop
            previousDistance = distance;

            yield return null;
        }
    }
}
