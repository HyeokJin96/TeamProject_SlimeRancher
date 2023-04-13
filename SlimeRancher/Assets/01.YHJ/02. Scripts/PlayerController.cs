using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = default;
    [SerializeField] private float sprintSpeed = default;
    [SerializeField] private float normalSpeed = default;
    [SerializeField] private float jumpForce = default;

    [SerializeField] private float groundCheckDistance = default;
    [SerializeField] private LayerMask groundLayer = default;

    private bool isGrounded = false;
    private bool isSprinting = false;


    private Rigidbody playerRigidbody = default;


    [Space(20f)]
    [SerializeField] private GameObject vacpack = default;
    [SerializeField] private Animator vacpackAnimator = default;
    [SerializeField] private GameManager gameManager = default;
    [SerializeField] private Camera playerCamera = default;
    [SerializeField] private CameraController cameraController = default;

    private float currentX;
    private float currentY;


    private GameObject hand = default;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        vacpack = transform.GetChild(0).GetChild(1).gameObject;
        vacpackAnimator = vacpack.GetComponent<Animator>();
        playerCamera = transform.GetChild(0).GetChild(0).GetComponent<Camera>();
        cameraController = playerCamera.GetComponent<CameraController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        hand = transform.GetChild(0).gameObject;
    }

    private void Start()
    {
        normalSpeed = moveSpeed;
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Update()
    {
        Jump();
        Sprint();
        AnimationControll();
        RotatePlayer();
    }

    private void RotatePlayer()
    {
        //RotateCharacter();
        RotateVacpack();
    }

    private void RotateCharacter()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * gameManager.mouseSensitivity;

        currentX += mouseX;

        this.transform.rotation = Quaternion.Euler(0f, currentX, 0f);
    }



    private void RotateVacpack()
    {
        float mouseY = Input.GetAxisRaw("Mouse Y") * gameManager.mouseSensitivity;
        currentY -= mouseY;
        currentY = Mathf.Clamp(currentY, cameraController.minAngle, cameraController.maxAngle);
        hand.transform.rotation = Quaternion.Euler(currentY, 0f, 0f);
    }











    private void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = (horizontalInput * transform.right + verticalInput * transform.forward).normalized;
        Vector3 newPosition = transform.position + moveDirection * moveSpeed * Time.deltaTime;
        playerRigidbody.MovePosition(newPosition);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
    }

    private void Sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
        {
            if (!isSprinting)
            {
                isSprinting = true;
                moveSpeed = sprintSpeed;
            }
            else
            {
                isSprinting = false;
                moveSpeed = normalSpeed;
            }
        }
    }

    private void Absorption()
    {
        if (Input.GetMouseButton(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    Vector3 direction = transform.position - hit.transform.position;
                    rb.AddForce(direction.normalized * 10f);
                }
            }
        }
    }

    private void AnimationControll()
    {
        if (isSprinting)
        {
            vacpackAnimator.SetBool("isSprinting", true);
        }
        else
        {
            vacpackAnimator.SetBool("isSprinting", false);
        }
    }

}