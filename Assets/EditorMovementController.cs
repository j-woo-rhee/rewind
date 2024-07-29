using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorMovementController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float lookSpeed = 2f;

    private Transform cameraTransform;
    private float rotationX = 0f;
    private float rotationY = 0f;

    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        HandleMovement();
        HandleMouseLook();
    }

    void HandleMovement()
    {
        // Handle movement
        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right arrow keys
        float vertical = Input.GetAxis("Vertical"); // W/S or Up/Down arrow keys
        Vector3 moveDirection = cameraTransform.forward * vertical + cameraTransform.right * horizontal;
        moveDirection.y = 0; // Prevent vertical movement
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    void HandleMouseLook()
    {
        // Handle rotation
        if (Input.GetMouseButton(1)) // Right mouse button to look around
        {
            float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
            float mouseY = -Input.GetAxis("Mouse Y") * lookSpeed;

            rotationX += mouseX;
            rotationY += mouseY;
            rotationY = Mathf.Clamp(rotationY, -90f, 90f);

            cameraTransform.localRotation = Quaternion.Euler(rotationY, rotationX, 0);
        }
    }
}
