using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private Controls controls;

    [SerializeField] private float mouseSensitivity = 1f;

    private Vector2 look;
    private float xRotation;

    private Transform playerBody;

    private void Awake()
    {
        controls = new Controls();

        Cursor.lockState = CursorLockMode.Locked;

        playerBody = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        look = controls.Gameplay.Look.ReadValue<Vector2>();

        var MouseX = (look.x * Time.deltaTime) * mouseSensitivity;
        var MouseY = (look.y * Time.deltaTime) * mouseSensitivity;

        xRotation -= MouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * MouseX);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
