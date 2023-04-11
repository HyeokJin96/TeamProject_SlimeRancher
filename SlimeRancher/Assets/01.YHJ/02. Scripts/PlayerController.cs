using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = default;
    [SerializeField] private float jumpForce = default;


    [SerializeField] private float groundCheckDistance = default;
    [SerializeField] private LayerMask groundLayer = default;

    private bool isGrounded = false;

    float suctionForce = 10f;
    float launchForce = 10f;
    public Transform nozzle; // ������ ����
    public LayerMask slimeLayer; // ������ ���̾�


    private Rigidbody playerRigidbody = default;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Update()
    {
        KeyControll();
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = (horizontalInput * transform.right + verticalInput * transform.forward).normalized;
        Vector3 newPosition = transform.position + moveDirection * moveSpeed * Time.deltaTime;
        playerRigidbody.MovePosition(newPosition);
    }

    private void KeyControll()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);

        // ���콺 ���� ��ư ���� �� ������ ���
        if (Input.GetMouseButton(0))
        {
            // ������ ���
            Collider[] slimeColliders = Physics.OverlapSphere(nozzle.position, 0.5f, slimeLayer);
            foreach (Collider slimeCollider in slimeColliders)
            {
                Rigidbody slimeRigidbody = slimeCollider.GetComponent<Rigidbody>();
                if (slimeRigidbody != null)
                {
                    Vector3 direction = slimeRigidbody.position - playerRigidbody.position;
                    slimeRigidbody.AddForce(direction.normalized * suctionForce, ForceMode.Force);
                }
            }
        }
        // ���콺 ������ ��ư ���� �� ������ �߻�
        else if (Input.GetMouseButton(1))
        {
            // ������ �߻�
            Collider[] slimeColliders = Physics.OverlapSphere(nozzle.position, 0.5f, slimeLayer);
            foreach (Collider slimeCollider in slimeColliders)
            {
                Rigidbody slimeRigidbody = slimeCollider.GetComponent<Rigidbody>();
                if (slimeRigidbody != null)
                {
                    Vector3 direction = slimeRigidbody.position - playerRigidbody.position;
                    slimeRigidbody.AddForce(direction.normalized * launchForce, ForceMode.Impulse);
                }
            }
        }
    }
}