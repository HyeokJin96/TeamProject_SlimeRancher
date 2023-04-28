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
    [SerializeField] private GameObject pivot = default;
    [SerializeField] private GameObject vacpack = default;
    [SerializeField] private GameObject arms = default;
    [SerializeField] private GameObject playerBody = default;

    [Space(10f)]
    [SerializeField] private Camera playerCamera = default;

    [Space(10f)]
    [SerializeField] private Animator playerAnimator = default;
    [SerializeField] private CameraController cameraController = default;

    [Space(10f)]
    [SerializeField] private GameManager gameManager = default;





    private float currentX;
    private float currentY;


    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        pivot = transform.GetChild(0).transform.gameObject;
        playerCamera = pivot.transform.GetChild(0).GetComponent<Camera>();
        vacpack = pivot.transform.GetChild(1).gameObject;
        arms = pivot.transform.GetChild(2).gameObject;
        playerBody = transform.GetChild(1).gameObject;



        cameraController = playerCamera.GetComponent<CameraController>();
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
        RotatePlayer();

        AnimationControll();
        //Absorption();
    }

    #region RotatePlayer
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
        vacpack.transform.parent.transform.rotation = transform.rotation * vacpackTargetRotation;
    }   //  RotatePlayer()
    #endregion

    #region Movement
    private void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = (horizontalInput * transform.right + verticalInput * transform.forward).normalized;
        Vector3 newPosition = transform.position + moveDirection * moveSpeed * Time.deltaTime;
        playerRigidbody.MovePosition(newPosition);
    }   //  Movement()
    #endregion

    #region Jump
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
    }   //  Jump()
    #endregion

    #region Sprint
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
    }   //  Sprint()
    #endregion

    //private void Absorption()
    //{
    //    if (Input.GetMouseButton(1))
    //    {
    //        cone.gameObject.SetActive(true);
    //    }

    //    if (Input.GetMouseButtonUp(1))
    //    {
    //        cone.gameObject.SetActive(false);
    //    }
    //}

    private void AnimationControll()
    {
        if (isSprinting)
        {
            playerAnimator.SetBool("isSprinting", true);
        }
        else
        {
            playerAnimator.SetBool("isSprinting", false);
        }
    }

}