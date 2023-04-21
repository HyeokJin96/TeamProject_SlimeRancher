using UnityEngine;
using UnityEngine.UI;

public class Player_Raycast : MonoBehaviour
{
    [SerializeField] private Canvas canvas_Ui = default;
    [SerializeField] private Camera mainCamera = default;
    [SerializeField] private GameObject muzzle = default;
    [SerializeField] private GameObject crosshair = default;
    [SerializeField] private ObjecData objectData = default;
    [SerializeField] private GameObject targetObject = default;
    [SerializeField] private Image crosshairImage = default;

    [SerializeField] private float targetObjectDistance = default;
    [SerializeField] private float raycastDistance = default;

    private RaycastHit objectType = default;

    private bool canAbsorb = false;

    private void Awake()
    {
        mainCamera = Camera.main;
        canvas_Ui = FindAnyObjectByType<Canvas>();
        muzzle = transform.GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(0).gameObject;
        crosshair = canvas_Ui.transform.GetChild(12).gameObject;
        crosshairImage = crosshair.transform.GetChild(0).GetComponent<Image>();
    }

    private void Update()
    {
        Ray raycast = mainCamera.ScreenPointToRay(crosshair.transform.position);

        if (Physics.Raycast(raycast, out objectType, raycastDistance))
        {
            targetObject = objectType.collider.transform.parent.gameObject;
            objectData = targetObject.GetComponentInParent<ObjecData>();

            if (objectData != null)
            {
                Debug.DrawLine(muzzle.transform.position, objectType.point, Color.red);
                crosshairImage.color = Color.green;
                canAbsorb = true;
            }
        }
        else
        {
            targetObject = null;
            crosshairImage.color = Color.white;
            canAbsorb = false;
        }
    }
}

//if (objectData != null)
//{
//    crosshairImage.color = Color.green;

//    Debug.Log("Object Type: " + objectData.objectType);

//    if (objectData.objectType == ObjectType.Food && objectData.foodType != FoodType.none)
//    {
//        Debug.Log("Food Type: " + objectData.foodType);
//        Debug.Log("Food Name: " + objectData.foodName);
//    }
//}
