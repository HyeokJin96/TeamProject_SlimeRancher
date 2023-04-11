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
    public Transform nozzle; // 진공팩 노즐
    public LayerMask slimeLayer; // 슬라임 레이어


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

        // 마우스 왼쪽 버튼 누를 때 슬라임 흡수
        if (Input.GetMouseButton(0))
        {
            // 슬라임 흡수
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
        // 마우스 오른쪽 버튼 누를 때 슬라임 발사
        else if (Input.GetMouseButton(1))
        {
            // 슬라임 발사
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