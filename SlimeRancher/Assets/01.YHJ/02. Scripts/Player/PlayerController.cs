using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager = default;

    [SerializeField] private float groundCheckDistance = default;
    [SerializeField] private LayerMask groundLayer = default;

    private bool isGrounded = false;
    public bool isSprinting = false;
    public bool isInAction = false;


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


    private Player_Raycast player_Raycast = default;


    public static float currentX;
    public static float currentY;

    public bool canMove = false;
    public bool isFlying = false;

    private float maxHealth;
    private float currentHealth;
    private float maxEnergy;
    private float currentEnergy;
    private float coin;

    private Vector3 playerPos = default;
    private float pressedTime = default;

    private void Awake()
    {
        playerManager = this.GetComponent<PlayerManager>();

        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        pivot = transform.GetChild(0).transform.gameObject;
        playerCamera = pivot.transform.GetChild(0).GetComponent<Camera>();
        vacpack = pivot.transform.GetChild(1).gameObject;
        arms = pivot.transform.GetChild(2).gameObject;
        playerBody = transform.GetChild(1).gameObject;


        player_Raycast = GetComponent<Player_Raycast>();

        cameraController = playerCamera.GetComponent<CameraController>();
    }

    private void Start()
    {
        playerManager.playerSpeed = playerManager.playerMoveSpeed;
        canMove = true;
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            Movement();
        }
    }

    private void Update()
    {
        PlayerPosCheck();

        if (canMove)
        {
            Jump();
            JetPack();
            Sprint();
            RotatePlayer();

            AnimationControll();
            //Absorption();
        }
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
        Vector3 newPosition = transform.position + moveDirection * playerManager.playerSpeed * Time.deltaTime;
        playerRigidbody.MovePosition(newPosition);
    }   //  Movement()
    #endregion

    #region Jump
    private void Jump()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRigidbody.AddForce(Vector3.up * playerManager.playerJumpForce, ForceMode.Impulse);
        }

        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);

    }   //  Jump()
    #endregion

    private void JetPack()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            pressedTime += Time.deltaTime;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isFlying = false;

            if (isGrounded)
            {
                pressedTime = 0;
            }
        }

        if (Input.GetKey(KeyCode.Space) && playerManager.hasJetpack)
        {
            if (pressedTime >= 0.5f)
            {
                if (transform.position.y < playerPos.y + 10f)
                {
                    playerRigidbody.AddForce(Vector3.up * playerManager.playerJetPackForce, ForceMode.Force);
                }
                else
                {
                    playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, 0, playerRigidbody.velocity.z);
                }

                isFlying = true;
            }
        }
    }



    private void PlayerPosCheck()
    {
        if (!isFlying)
        {
            playerPos = transform.position;
        }
        else
        {
            return;
        }
    }

    #region Sprint
    private void Sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
        {
            isSprinting = !isSprinting;
        }
    }   //  Sprint()
    #endregion

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