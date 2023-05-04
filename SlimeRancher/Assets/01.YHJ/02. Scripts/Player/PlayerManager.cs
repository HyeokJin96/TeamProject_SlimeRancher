using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [Header ("Movement")]
    [SerializeField] public float playerSpeed = default;
    [SerializeField] public float playerMoveSpeed = default;
    [SerializeField] public float playerSprintSpeed = default;
    [SerializeField] public float playerJumpForce = default;
    [SerializeField] public float playerJetPackForce = default;

    [Header ("Health")]
    [SerializeField] public float playerCurrentHealth = default;
    [SerializeField] public float playerMaxHealth = default;

    [Header("Energy")]
    [SerializeField] public float playerCurrentEnergy = default;
    [SerializeField] public float playerMaxEnergy = default;
    [SerializeField] public float playerPowerConsumption = default;
    [SerializeField] public float playerJetpackConsumption = default;
    [SerializeField] public float playerEnergyincrease = default;

    [Header("Storage")]
    [SerializeField] public float playerStorageSpace = default;

    [Header("NewbucksCoin")]
    [SerializeField] public float playerNewbucksCoin = default;

    [Header("ETC")]
    [SerializeField] private Canvas canvas = default;
    [SerializeField] private PlayerController playerController = default;
    [SerializeField] private GameObject player_Ui = default;

    [SerializeField] private GameObject player_Coin = default;
    [SerializeField] private GameObject player_Health = default;
    [SerializeField] private GameObject player_HealthBar = default;
    [SerializeField] private GameObject player_Energy = default;
    [SerializeField] private Image player_EnegyBar = default;

    [SerializeField] private TMP_Text player_Coin_Text = default;
    [SerializeField] private TMP_Text player_Health_Text = default;
    [SerializeField] private TMP_Text player_Energy_Text = default;

    private bool isInAction = false;
    private float delayTime = default;
    private float delayTimer = default;

    public bool hasJetpack = false;

    private void Awake()
    {
        canvas = GameObject.FindObjectOfType<Canvas>();
        playerController = this.GetComponent<PlayerController>();
        player_Ui = canvas.transform.GetChild(0).gameObject;

        player_Coin = player_Ui.transform.GetChild(0).gameObject;
        player_Health = player_Ui.transform.GetChild(1).gameObject;
        player_Energy = player_Ui.transform.GetChild(2).gameObject;
        player_EnegyBar = player_Energy.transform.GetChild(1).GetChild(1).GetComponent<Image>();

        player_Coin_Text = player_Coin.transform.GetChild(1).GetComponent<TMP_Text>();
        player_Health_Text = player_Health.transform.GetChild(2).GetComponent<TMP_Text>();
        player_Energy_Text = player_Energy.transform.GetChild(2).GetComponent<TMP_Text>();

        playerCurrentHealth = playerMaxHealth;
        playerCurrentEnergy = playerMaxEnergy;


        delayTime = 2f;
    }

    private void Update()
    {
        UdatePlayerUi();

        PlayerEnergy();
    }

    private void UdatePlayerUi()
    {
        player_Coin_Text.text = playerNewbucksCoin.ToString("F0");
        player_Health_Text.text = playerCurrentHealth.ToString("F0");
        player_Energy_Text.text = playerCurrentEnergy.ToString("F0");
    }

    private void PlayerHealth()
    {

    }

    private void PlayerEnergy()
    {
        if (playerController.isSprinting)
        {
            playerSpeed = playerSprintSpeed;
            playerCurrentEnergy -= Time.deltaTime * playerPowerConsumption;

            player_EnegyBar.fillAmount = playerCurrentEnergy / playerMaxEnergy;

            if (playerCurrentEnergy <= 0)
            {
                playerCurrentEnergy = 0;
                playerSpeed = playerMoveSpeed;
                playerController.isSprinting = false;
            }

            delayTimer = 0;
        }
        else
        {
            playerSpeed = playerMoveSpeed;

            if (playerCurrentEnergy < playerMaxEnergy)
            {
                delayTimer += Time.deltaTime;

                if (delayTimer > delayTime)
                {
                    playerCurrentEnergy += Time.deltaTime * playerEnergyincrease;
                    player_EnegyBar.fillAmount = playerCurrentEnergy / playerMaxEnergy;

                    if (playerCurrentEnergy > playerMaxEnergy)
                    {
                        playerCurrentEnergy = playerMaxEnergy;
                    }
                }
            }
        }

        if (playerController.isFlying)
        {
            playerCurrentEnergy -= Time.deltaTime * playerJetpackConsumption;
            player_EnegyBar.fillAmount = playerCurrentEnergy / playerMaxEnergy;

            if (playerCurrentEnergy <= 0)
            {
                playerCurrentEnergy = 0;
                playerJetPackForce = 0;
                playerController.isFlying = false;
            }

            delayTimer = 0;
        }
        else
        {
            playerJetPackForce = 6f;

            if (playerCurrentEnergy < playerMaxEnergy)
            {
                delayTimer += Time.deltaTime;

                if (delayTimer > delayTime)
                {
                    playerCurrentEnergy += Time.deltaTime * playerEnergyincrease;
                    player_EnegyBar.fillAmount = playerCurrentEnergy / playerMaxEnergy;

                    if (playerCurrentEnergy > playerMaxEnergy)
                    {
                        playerCurrentEnergy = playerMaxEnergy;
                    }
                }
            }
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Water"))
    //    {
    //        /* Die */
    //    }
    //}

}
