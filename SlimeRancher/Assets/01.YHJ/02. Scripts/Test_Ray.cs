using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Ray : MonoBehaviour
{
    [SerializeField] private Transform vacpack = default;
    private Ray ray;

    private void Awake()
    {
        vacpack = transform.GetChild(0).GetChild(0).GetChild(1);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ray = new Ray(vacpack.position, GetRayDirection());
        }

        if (Input.GetMouseButtonUp(1))
        {
            ray = new Ray();
        }

        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 1f);

        if (ray.direction != Vector3.zero)
        {
            Raycast();
        }
    }

    private Vector3 GetRayDirection()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 direction = (mousePosition - Camera.main.WorldToScreenPoint(vacpack.position)).normalized;

        return new Vector3(direction.x, 0, direction.y);
    }

    private void Raycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Hit Object : " + hit.collider.gameObject.name);
        }
    }

}
