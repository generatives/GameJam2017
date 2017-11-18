using System;
using UnityEngine;
using UnityEngine.Networking;

public class MouseLook : NetworkBehaviour
{
    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;

    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis
    private bool cameraAttached = false;

    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (!cameraAttached)
        {
            if (isLocalPlayer)
            {
                GameObject camera = GameObject.Find("Camera");
                if (camera != null)
                {
                    camera.transform.SetParent(this.transform);
                    camera.transform.localPosition = Vector3.zero;
                }
            }
        }

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;
    }
}