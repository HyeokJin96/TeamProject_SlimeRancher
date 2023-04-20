using UnityEngine;

public class Test_Ray : MonoBehaviour
{
    [SerializeField] private Camera mainCamera = default;
    [SerializeField] private GameObject muzzle = default;
    [SerializeField] private GameObject crosshair = default;
    [SerializeField] private test testScript = default;

    [SerializeField] private float targetObjectDistance = default;
    [SerializeField] private float raycastDistance = default;

    private RaycastHit objectType = default;

    private GameObject targetObject = default;

    private void Awake()
    {
        mainCamera = Camera.main;
        muzzle = transform.GetChild(0).GetChild(0).GetChild(2).gameObject;
        crosshair = transform.GetChild(2).GetChild(4).gameObject;
    }

    private void Update()
    {
        Ray raycast = mainCamera.ScreenPointToRay(crosshair.transform.position);

        if (Input.GetMouseButton(1))
        {
            if (Physics.Raycast(raycast, out objectType, raycastDistance))
            {
                targetObject = objectType.collider.transform.parent.gameObject;
                testScript = targetObject.GetComponentInParent<test>();
                if (testScript != null)
                {
                    Debug.Log("Food type: " + testScript.foodType);
                }
                Debug.DrawLine(muzzle.transform.position, objectType.point, Color.red);
            }
            else
            {
                targetObject = null;
            }
        }
    }

}
