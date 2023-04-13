using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player = default;

    [SerializeField] private float mouseSensitivity = default;
    [SerializeField] private float maxAngle = default;
    [SerializeField] private float minAngle = default;

    private float currentX = default;
    private float currentY = default;

    private void Awake()
    {
        player = transform.parent;
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity;

        currentX += mouseX;
        currentY -= mouseY;

        currentY = Mathf.Clamp(currentY, minAngle, maxAngle);

        player.transform.rotation = Quaternion.Euler(currentY, currentX, 0);
    }
}
