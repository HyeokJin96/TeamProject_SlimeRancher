using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("플레이어")]
    [SerializeField] private float moveSpeed = default; 

    [Header("카메라")] 
    [SerializeField] private Camera playerCamera = default;
    [SerializeField] private float cameraSensitivity = default;
    [SerializeField] private float cameraRotationLimit = default;
    [SerializeField] private float currentCameraRotationX = default;

    private Rigidbody playerRigidbody = default;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerCamera = transform.GetChild(0).GetComponent<Camera>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Update()
    {
        RotateCharacter();
        RotateCamera();
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = (horizontalInput * transform.right + verticalInput * transform.forward).normalized;
        Vector3 newPosition = transform.position + moveDirection * Time.deltaTime * moveSpeed;
        playerRigidbody.MovePosition(newPosition);
    }   //  Movement()

    private void RotateCharacter()
    {
        float rotationY = Input.GetAxisRaw("Mouse X") * cameraSensitivity;
        playerRigidbody.MoveRotation(playerRigidbody.rotation * Quaternion.Euler(0f, rotationY, 0f));
    }   //  CharacterRotation()

    private void RotateCamera()
    {
        float rotationX = Input.GetAxisRaw("Mouse Y") * cameraSensitivity;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX - rotationX, -cameraRotationLimit, cameraRotationLimit);
        playerCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
    }

}
