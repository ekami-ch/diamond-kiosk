using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAroundObject : MonoBehaviour
{
    // Mouse Sensitivity
    public float _mouseSensitivity = 3.0f;

    private float _rotationY;
    private float _rotationX;

    // Target Object
    public Transform _target;

    // Distance from Target
    public float _distanceFromTarget = 3.0f;

    private Vector3 _currentRotation;
    private Vector3 _smoothVelocity = Vector3.zero;

    private float _smoothTime = 0.2f;

    private Vector2 _rotationXMinMax = new Vector2(1, 40);

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity;

        _rotationY += mouseX;
        _rotationX += mouseY;

        // Apply clamping for x rotation 
        _rotationX = Mathf.Clamp(_rotationX, _rotationXMinMax.x, _rotationXMinMax.y);

        Vector3 nextRotation = new Vector3(31.0f, _rotationY);

        // Apply damping between rotation changes
        _currentRotation = Vector3.SmoothDamp(_currentRotation, nextRotation, ref _smoothVelocity, _smoothTime);
        transform.localEulerAngles = _currentRotation;

        // Substract forward vector of the GameObject to point its forward vector to the target
        transform.position = _target.position - transform.forward * _distanceFromTarget;
    }
}
