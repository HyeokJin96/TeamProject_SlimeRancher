using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FacilityController : MonoBehaviour
{
    [SerializeField] private GameObject player = default;
    [SerializeField] private Player_Raycast player_Raycast = default;
    [SerializeField] private PlayerController playerController = default;
    [SerializeField] private Canvas canvas = default;

    [SerializeField] private GameObject interaction_GameObject = default;

    [SerializeField] private GameObject[] button_Facility = default;

    [SerializeField] private GameObject[] ui_Facility = default;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        canvas = FindObjectOfType<Canvas>();
        player_Raycast = player.GetComponent<Player_Raycast>();
        playerController = player.GetComponent<PlayerController>();
        interaction_GameObject = canvas.transform.GetChild(9).gameObject;

        button_Facility = new GameObject[interaction_GameObject.transform.GetChild(1).childCount];

        for (int i = 0; i < button_Facility.Length; i++)
        {
            button_Facility[i] = interaction_GameObject.transform.GetChild(1).GetChild(i).gameObject;
        }

        ui_Facility = new GameObject[canvas.transform.GetChild(11).childCount];

        for (int i = 0; i < ui_Facility.Length; i++)
        {
            ui_Facility[i] = canvas.transform.GetChild(11).GetChild(i).gameObject;
        }
    }

    private void Update()
    {
        if (player_Raycast.isAppearing_Facility_1)
        {
            button_Facility[0].SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                playerController.canMove = false;
                ui_Facility[0].SetActive(true);

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
        else
        {
            button_Facility[0].SetActive(false);
            ui_Facility[0].SetActive(false);
        }

        if (player_Raycast.isAppearing_Facility_2)
        {
            button_Facility[1].SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                playerController.canMove = false;
                ui_Facility[1].SetActive(true);

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
        else
        {
            button_Facility[1].SetActive(false);
            ui_Facility[1].SetActive(false);
        }

        if (player_Raycast.isAppearing_Facility_3)
        {
            button_Facility[2].SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                playerController.canMove = false;
                ui_Facility[2].SetActive(true);

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
        else
        {
            button_Facility[2].SetActive(false);
            ui_Facility[2].SetActive(false);
        }

        if (player_Raycast.isAppearing_Facility_4)
        {
            button_Facility[3].SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                playerController.canMove = false;
                ui_Facility[3].SetActive(true);

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
        else
        {
            button_Facility[3].SetActive(false);
            ui_Facility[3].SetActive(false);
        }

        if (player_Raycast.isAppearing_Facility_5)
        {
            button_Facility[4].SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                playerController.canMove = false;
                ui_Facility[4].SetActive(true);

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
        else
        {
            button_Facility[4].SetActive(false);
            ui_Facility[4].SetActive(false);
        }

        if (player_Raycast.isAppearing_Facility_6)
        {
            button_Facility[5].SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                playerController.canMove = false;
                ui_Facility[5].SetActive(true);

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
        else
        {
            button_Facility[5].SetActive(false);
            ui_Facility[5].SetActive(false);
        }

        if (player_Raycast.isAppearing_Facility_7)
        {
            button_Facility[6].SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                playerController.canMove = false;
                ui_Facility[6].SetActive(true);

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
        else
        {
            button_Facility[6].SetActive(false);
            ui_Facility[6].SetActive(false);
        }

        if (player_Raycast.isAppearing_Facility_8)
        {
            button_Facility[7].SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                playerController.canMove = false;
                ui_Facility[7].SetActive(true);

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
        else
        {
            button_Facility[7].SetActive(false);
            ui_Facility[7].SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            playerController.canMove = true;

            for (int i = 0; i < ui_Facility.Length; i++)
            {
                ui_Facility[i].SetActive(false);
            }

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
