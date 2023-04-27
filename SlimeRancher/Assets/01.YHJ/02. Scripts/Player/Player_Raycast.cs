using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player_Raycast : MonoBehaviour
{
    [SerializeField] private Canvas canvas_Ui = default;
    [SerializeField] private Camera mainCamera = default;
    [SerializeField] private GameObject vac_Muzzle = default;

    [SerializeField] private GameObject crosshair = default;
    [SerializeField] private ObjecData objectData = default;
    [SerializeField] private GameObject targetObject = default;
    [SerializeField] private Image crosshairImage = default;

    [SerializeField] private float targetObjectDistance = default;
    [SerializeField] private float raycastDistance = default;

    private RaycastHit objectType = default;

    private bool canAbsorb = false;

    [HideInInspector] public bool isAppearing = false;

    private void Awake()
    {
        mainCamera = Camera.main;
        canvas_Ui = FindAnyObjectByType<Canvas>();

        vac_Muzzle = transform.GetChild(0).GetChild(1).GetChild(3).gameObject;
        crosshair = canvas_Ui.transform.GetChild(12).gameObject;
        crosshairImage = crosshair.transform.GetChild(0).GetComponent<Image>();

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

            if (objectData.objectType == ObjectType.Button && targetObject.transform.position.x - this.transform.position.x < 0.5)
            {
                isAppearing = true;
            }
            else
            {
                isAppearing = false;
            }
        }
        else
        {
            crosshairImage.color = Color.white;
            canAbsorb = false;
            isAppearing = false;
        }
    }
}
