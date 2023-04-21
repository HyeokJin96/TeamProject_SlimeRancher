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
    [SerializeField] private GameObject playerBody = default;
    [SerializeField] private GameObject vacpackPivot = default;
    [SerializeField] private GameObject model_V3 = default;
    [SerializeField] private GameObject muzzle = default;
    [SerializeField] private GameObject cone = default;

    [Space(10f)]
    [SerializeField] private Camera playerCamera = default;

    [Space(10f)]
    [SerializeField] private Animator vacpackAnimator = default;
    [SerializeField] private CameraController cameraController = default;

    [Space(10f)]
    [SerializeField] private GameManager gameManager = default;





    private float currentX;
    private float currentY;


    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        vacpack = transform.GetChild(0).gameObject;
        playerBody = transform.GetChild(1).gameObject;
        vacpackPivot = vacpack.transform.GetChild(0).gameObject;
        model_V3 = vacpackPivot.transform.GetChild(1).gameObject;
        muzzle = vacpackPivot.transform.GetChild(1).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(0).gameObject;
        cone = muzzle.transform.GetChild(0).gameObject;
        playerCamera = vacpackPivot.transform.GetChild(0).gameObject.GetComponent<Camera>();

        cameraController = playerCamera.GetComponent<CameraController>();
        vacpackAnimator = model_V3.GetComponent<Animator>();
    }

    private void Start()
    {
        normalSpeed = moveSpeed;
        //cone.gameObject.SetActive(false);
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
        //Absorption();
    }

    private void RotatePlayer()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * gameManager.mouseSensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * gameManager.mouseSensitivity;

        currentX += mouseX;
        currentY -= mouseY;
        currentY = Mathf.Clamp(currentY, cameraController.minAngle, cameraController.maxAngle);

        Quaternion characterTargetRotation = Quaternion.Euler(0f, currentX, 0f);
        Quaternion vacpackTargetRotation = Quaternion.Euler(currentY, 0f, 0f);

        transform.rotation = characterTargetRotation;
        vacpackPivot.transform.rotation = transform.rotation * vacpackTargetRotation;
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
            cone.gameObject.SetActive(true);
        }

        if (Input.GetMouseButtonUp(1))
        {
            cone.gameObject.SetActive(false);
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