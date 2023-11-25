using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{


    public float rotationSpeed = 5.0f;
    public GameObject Camera;
    public float maxVerticalAngle = 80.0f; // Adjust this to set the maximum looking up angle
    public float minVerticalAngle = -80.0f; // Adjust this to set the maximum looking down angle

    private float verticalRotation = 0.0f;

    public void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Rotate the camera based on mouse input
        Camera.transform.Rotate(Vector3.up, mouseX * rotationSpeed, Space.World);

        // Update the vertical rotation with clamps
        verticalRotation -= mouseY * rotationSpeed;
        verticalRotation = Mathf.Clamp(verticalRotation, minVerticalAngle, maxVerticalAngle);

        // Apply the vertical rotation
        Camera.transform.localRotation = Quaternion.Euler(verticalRotation, Camera.transform.localRotation.eulerAngles.y, 0);
    }

}
