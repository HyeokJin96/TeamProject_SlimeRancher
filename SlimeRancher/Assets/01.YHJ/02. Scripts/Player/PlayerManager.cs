using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] public int playerSpeed = default;
    [SerializeField] public int playerMoveSpeed = default;
    [SerializeField] public int playerSprintSpeed = default;
    [SerializeField] public int playerJumpForce = default;


    [SerializeField] public int playerMaxHeart = default;
    [SerializeField] public int playerCurrentHeart = default;

    [SerializeField] public int playerMaxPower = default;
    [SerializeField] public int playerCurrentPower = default;

    [SerializeField] public int playerStorageSpace = default;

    [SerializeField] public int playerNewbucksCoin = default;


    [SerializeField] private Canvas canvas = default;
    [SerializeField] private GameObject player_Ui = default;

    [SerializeField] private GameObject player_Coin = default;
    [SerializeField] private GameObject player_Health = default;
    [SerializeField] private GameObject player_Power = default;

    [SerializeField] private TMP_Text player_Coin_Text = default;
    [SerializeField] private TMP_Text player_Health_Text = default;
    [SerializeField] private TMP_Text player_Power_Text = default;

    private void Awake()
    {
        canvas = GameObject.FindObjectOfType<Canvas>();
        player_Ui = canvas.transform.GetChild(0).gameObject;

        player_Coin = player_Ui.transform.GetChild(0).gameObject;
        player_Health = player_Ui.transform.GetChild(1).gameObject;
        player_Power = player_Ui.transform.GetChild(2).gameObject;

        player_Coin_Text = player_Coin.transform.GetChild(1).GetComponent<TMP_Text>();
        player_Health_Text = player_Health.transform.GetChild(2).GetComponent<TMP_Text>();
        player_Power_Text = player_Power.transform.GetChild(2).GetComponent<TMP_Text>();
    }

    private void Start()
    {
        playerMoveSpeed = 8;
        playerSprintSpeed = 20;
        playerJumpForce = 6;

        playerMaxHeart = 100;
        playerCurrentHeart = playerMaxHeart;

        playerMaxPower = 100;
        playerCurrentPower = playerMaxPower;

        playerStorageSpace = 20;

        playerNewbucksCoin = 10000;
    }

    private void Update()
    {
        player_Coin_Text.text = playerNewbucksCoin.ToString();
        player_Health_Text.text = playerCurrentHeart.ToString();
        player_Power_Text.text = playerCurrentPower.ToString();
    }
}
