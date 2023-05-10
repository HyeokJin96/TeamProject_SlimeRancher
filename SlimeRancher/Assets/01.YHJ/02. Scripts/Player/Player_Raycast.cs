using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player_Raycast : MonoBehaviour
{
    [SerializeField] private Canvas canvas_Ui = default;
    [SerializeField] private Camera mainCamera = default;
    [SerializeField] private GameObject vac_Muzzle = default;
    [SerializeField] private GameObject player_Ui = default;

    [SerializeField] private GameObject crosshair = default;
    [SerializeField] private ObjecData objectData = default;
    [SerializeField] private GameObject targetObject = default;
    [SerializeField] private Image crosshairImage = default;

    [SerializeField] private float targetObjectDistance = default;
    [SerializeField] private float raycastDistance = default;

    private RaycastHit objectType = default;

    private bool canAbsorb = false;

    [HideInInspector] public bool isAppearing_UpgradeStation = false;
    [HideInInspector] public bool isAppearing_Facility_1 = false;
    [HideInInspector] public bool isAppearing_Facility_2 = false;
    [HideInInspector] public bool isAppearing_Facility_3 = false;
    [HideInInspector] public bool isAppearing_Facility_4 = false;
    [HideInInspector] public bool isAppearing_Facility_5 = false;
    [HideInInspector] public bool isAppearing_Facility_6 = false;
    [HideInInspector] public bool isAppearing_Facility_7 = false;
    [HideInInspector] public bool isAppearing_Facility_8 = false;

    private void Awake()
    {
        mainCamera = Camera.main;
        canvas_Ui = FindAnyObjectByType<Canvas>();
        player_Ui = canvas_Ui.transform.GetChild(0).gameObject;

        vac_Muzzle = transform.GetChild(0).GetChild(1).GetChild(3).gameObject;
        crosshair = player_Ui.transform.GetChild(4).gameObject;
        crosshairImage = crosshair.transform.GetChild(0).GetComponent<Image>();

        interaction_GameObject = canvas_Ui.transform.GetChild(9).gameObject;
        button_UpgradeStation = interaction_GameObject.transform.GetChild(0).gameObject;
        ui_UpgradeStation = canvas_Ui.transform.GetChild(10).gameObject;
    }

    private void Start()
    {
        button_UpgradeStation.SetActive(false);
        ui_UpgradeStation.SetActive(false);
    }

    private void Update()
    {
        Ray raycast = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
        int layerMask = ~(1 << LayerMask.NameToLayer("Ignore Raycast"));

        if (Physics.Raycast(raycast, out objectType, raycastDistance, layerMask))
        {
            targetObject = objectType.collider.gameObject;
            objectData = targetObject.transform.parent.GetComponentInParent<ObjecData>();
        }
        else
        {
            targetObject = null;
            objectData = null;
        }

        Vector3 direction = mainCamera.transform.position + mainCamera.transform.forward * raycastDistance;
        Debug.DrawLine(vac_Muzzle.transform.position, direction, Color.red);

        if (objectData != null)
        {
            crosshairImage.color = Color.green;
            canAbsorb = true;

            if (objectData.objectType == ObjectType.Button && Vector3.Distance(targetObject.transform.position, this.transform.position) < 2f)
            {
                switch (objectData.buttonType)
                {
                    case ButtonType.UpgradeStation:
                        isAppearing_UpgradeStation = true;

                        button_UpgradeStation.SetActive(true);

                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            UIManager.Instance.hasUiOpen = true;
                            this.GetComponent<PlayerController>().canMove = false;
                            ui_UpgradeStation.SetActive(true);

                            Cursor.lockState = CursorLockMode.None;
                            Cursor.visible = true;
                        }

                        break;
                    case ButtonType.Facility_1:
                        isAppearing_Facility_1 = true;
                        break;
                    case ButtonType.Facility_2:
                        isAppearing_Facility_2 = true;
                        break;
                    case ButtonType.Facility_3:
                        isAppearing_Facility_3 = true;
                        break;
                    case ButtonType.Facility_4:
                        isAppearing_Facility_4 = true;
                        break;
                    case ButtonType.Facility_5:
                        isAppearing_Facility_5 = true;
                        break;
                    case ButtonType.Facility_6:
                        isAppearing_Facility_6 = true;
                        break;
                    case ButtonType.Facility_7:
                        isAppearing_Facility_7 = true;
                        break;
                    case ButtonType.Facility_8:
                        isAppearing_Facility_8 = true;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                isAppearing_UpgradeStation = false;
                isAppearing_Facility_1 = false;
                isAppearing_Facility_2 = false;
                isAppearing_Facility_3 = false;
                isAppearing_Facility_4 = false;
                isAppearing_Facility_5 = false;
                isAppearing_Facility_6 = false;
                isAppearing_Facility_7 = false;
                isAppearing_Facility_8 = false;
            }
        }
        else
        {
            crosshairImage.color = Color.white;
            canAbsorb = false;
            isAppearing_UpgradeStation = false;
            isAppearing_Facility_1 = false;
            isAppearing_Facility_2 = false;
            isAppearing_Facility_3 = false;
            isAppearing_Facility_4 = false;
            isAppearing_Facility_5 = false;
            isAppearing_Facility_6 = false;
            isAppearing_Facility_7 = false;
            isAppearing_Facility_8 = false;
        }
    }
}
