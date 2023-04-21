using UnityEngine;

public class test_ff : MonoBehaviour
{
    public float rotationSpeed = 10f; // 회전 속도

    private float previousMouseX; // 이전 마우스 위치(x좌표)
    private float currentMouseX; // 현재 마우스 위치(x좌표)
    private HingeJoint hingeJoint; // Hinge Joint 컴포넌트

    private Rigidbody rb = default;

    private void Start()
    {
        hingeJoint = GetComponent<HingeJoint>();
    }

    private void FixedUpdate()
    {
        // 마우스 위치에 따라 회전
        currentMouseX = Input.mousePosition.x;
        float deltaMouseX = currentMouseX - previousMouseX;
        float rotationAngle = deltaMouseX * rotationSpeed * Time.fixedDeltaTime;
        hingeJoint.transform.Rotate(Vector3.forward, rotationAngle, Space.Self);
        previousMouseX = currentMouseX;
    }
}
