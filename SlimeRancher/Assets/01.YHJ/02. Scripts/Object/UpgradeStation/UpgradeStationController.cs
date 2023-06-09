using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeStationController : MonoBehaviour
{
    [SerializeField] private GameObject player = default;
    [SerializeField] private Player_Raycast player_Raycast = default;
    [SerializeField] private PlayerController playerController = default;
    [SerializeField] private Canvas canvas = default;

    [SerializeField] private GameObject interaction_GameObject = default;
    [SerializeField] private GameObject button_UpgradeStation = default;
    [SerializeField] private GameObject button_UpgradeStation_Text = default;
    [SerializeField] private GameObject ui_UpgradeStation = default;

    private void Awake()
    {
        //player = GameObject.FindWithTag("Player");
        //canvas = FindObjectOfType<Canvas>();
        //player_Raycast = player.GetComponent<Player_Raycast>();
        //playerController = player.GetComponent<PlayerController>();
        //interaction_GameObject = canvas.transform.GetChild(9).gameObject;
        //button_UpgradeStation = interaction_GameObject.transform.GetChild(0).gameObject;
        //ui_UpgradeStation = canvas.transform.GetChild(10).gameObject;

        ui_UpgradeStation.SetActive(false);
        button_UpgradeStation.SetActive(false);
    }

    private void Update()
    {
        if (player_Raycast.isAppearing_UpgradeStation)
        {
            button_UpgradeStation.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                button_UpgradeStation_Text.SetActive(false);

                UIManager.Instance.hasUiOpen = true;
                playerController.canMove = false;
                ui_UpgradeStation.SetActive(true);

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
        else
        {
            button_UpgradeStation_Text.SetActive(true);

            button_UpgradeStation.SetActive(false);
            ui_UpgradeStation.SetActive(false);
        }
        // [KMS] 2023.05.07 Add Condition
        if (Input.GetKeyDown(KeyCode.Escape) && UIManager.Instance.isInGameMenu_Open == false)
        {
            playerController.canMove = true;
            ui_UpgradeStation.SetActive(false);
            UIManager.Instance.hasUiOpen = false;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
