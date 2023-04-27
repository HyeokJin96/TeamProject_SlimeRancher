using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRay : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    Color raycolor;
    // Start is called before the first frame update
    void Start()
    {
        //ray = new Ray(transform.position, transform.forward);
        raycolor = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(hit.collider);
        Debug.DrawRay(transform.position, transform.forward * 10, raycolor);
        Physics.Raycast(transform.position, transform.forward, out hit, 10f);
        if (hit.collider != null && hit.collider.tag == "Button")
        {
            raycolor = Color.green;

            //Debug.Log(Vector3.Distance(transform.position, hit.transform.position));
            UIManager.Instance.corralText.SetActive(true);
        }

        if (hit.collider == null)
        {
            raycolor = Color.red;
            UIManager.Instance.corralText.SetActive(false);
        }
    }
}
