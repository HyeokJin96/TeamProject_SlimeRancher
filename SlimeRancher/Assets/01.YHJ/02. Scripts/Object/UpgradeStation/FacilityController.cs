using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacilityController : MonoBehaviour
{
    [SerializeField] private GameObject player = default;
    [SerializeField] private Player_Raycast player_Raycast = default;
    [SerializeField] private PlayerController playerController = default;
    [SerializeField] private Canvas canvas = default;

    [SerializeField] private GameObject interaction_GameObject = default;
    [SerializeField] private GameObject Button_Facility = default;
    [SerializeField] private GameObject ui_Facility_Base = default;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        canvas = FindObjectOfType<Canvas>();
        player_Raycast = player.GetComponent<Player_Raycast>();
        playerController = player.GetComponent<PlayerController>();
        interaction_GameObject = canvas.transform.GetChild(9).gameObject;
        Button_Facility = interaction_GameObject.transform.GetChild(1).gameObject;
        ui_Facility_Base = canvas.transform.GetChild(11).gameObject;
    }

    private void Update()
    {
        if (player_Raycast.isAppearing_Facility)
        {
            Button_Facility.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                playerController.canMove = false;
                ui_Facility_Base.SetActive(true);

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
        else
        {
            Button_Facility.SetActive(false);
            ui_Facility_Base.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            playerController.canMove = true;
            ui_Facility_Base.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
