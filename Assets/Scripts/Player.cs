using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float mouseSensitivity = 0.15f;
    [SerializeField] Transform cameraTransform;

    CharacterController controller;
    float verticalRotation;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;

        // Sync to the camera's actual starting X rotation
        verticalRotation = cameraTransform.localEulerAngles.x;
        if (verticalRotation > 180f)
            verticalRotation -= 360f;
    }

    void Update()
    {
        Move();
        Look();
    }

    void Move()
    {
        var kb = Keyboard.current;
        if (kb == null) return;

        Vector2 input = Vector2.zero;
        if (kb.wKey.isPressed) input.y += 1f;
        if (kb.sKey.isPressed) input.y -= 1f;
        if (kb.dKey.isPressed) input.x += 1f;
        if (kb.aKey.isPressed) input.x -= 1f;

        Vector3 direction = transform.right * input.x + transform.forward * input.y;
        controller.SimpleMove(direction * moveSpeed);
    }

    void Look()
    {
        var mouse = Mouse.current;
        if (mouse == null) return;

        Vector2 delta = mouse.delta.ReadValue();

        transform.Rotate(Vector3.up, delta.x * mouseSensitivity);

        verticalRotation -= delta.y * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -80f, 80f);
        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }
}
