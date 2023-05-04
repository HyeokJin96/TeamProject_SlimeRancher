using UnityEngine;

public class test_ff : MonoBehaviour
{
    public float rotationSpeed = 10f; // ȸ�� �ӵ�

    private float previousMouseX; // ���� ���콺 ��ġ(x��ǥ)
    private float currentMouseX; // ���� ���콺 ��ġ(x��ǥ)
    private HingeJoint hingeJoint; // Hinge Joint ������Ʈ

    private Rigidbody rb = default;

    private void Start()
    {
        hingeJoint = GetComponent<HingeJoint>();
    }

    private void FixedUpdate()
    {
        // ���콺 ��ġ�� ���� ȸ��
        currentMouseX = Input.mousePosition.x;
        float deltaMouseX = currentMouseX - previousMouseX;
        float rotationAngle = deltaMouseX * rotationSpeed * Time.fixedDeltaTime;
        hingeJoint.transform.Rotate(Vector3.forward, rotationAngle, Space.Self);
        previousMouseX = currentMouseX;
    }
}
