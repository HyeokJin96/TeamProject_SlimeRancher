using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] public float maxAngle = default;
    [SerializeField] public float minAngle = default;



    //private void Update()
    //{
    //    float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity;
    //    float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity;

    //    currentX += mouseX;
    //    currentY -= mouseY;

    //    currentY = Mathf.Clamp(currentY, minAngle, maxAngle);

    //    player.transform.rotation = Quaternion.Euler(currentY, currentX, 0);
    //}
}
