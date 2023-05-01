using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeStationController : MonoBehaviour
{
    [SerializeField] private GameObject player = default;
    [SerializeField] private Player_Raycast player_Raycast = default;
    [SerializeField] private PlayerController playerController = default;
    [SerializeField] private Canvas canvas = default;

    [SerializeField] private GameObject interaction_GameObject = default;
    [SerializeField] private GameObject Button_UpgradeStation = default;
    [SerializeField] private GameObject ui_UpgradeStation = default;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        canvas = FindObjectOfType<Canvas>();
        player_Raycast = player.GetComponent<Player_Raycast>();
        playerController = player.GetComponent<PlayerController>();
        interaction_GameObject = canvas.transform.GetChild(9).gameObject;
        Button_UpgradeStation = interaction_GameObject.transform.GetChild(0).gameObject;
        ui_UpgradeStation = canvas.transform.GetChild(10).gameObject;
    }

    private void Update()
    {
        if (player_Raycast.isAppearing_UpgradeStation)
        {
            Button_UpgradeStation.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                playerController.canMove = false;
                ui_UpgradeStation.SetActive(true);

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
        else
        {
            Button_UpgradeStation.SetActive(false);
            ui_UpgradeStation.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            playerController.canMove = true;
            ui_UpgradeStation.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
