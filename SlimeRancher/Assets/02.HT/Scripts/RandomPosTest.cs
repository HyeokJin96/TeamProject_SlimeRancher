using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosTest : MonoBehaviour
{
    float radius = 10;
    float radiusX;
    float radiusZ;
    float angle;
    float posX;
    float posZ;

    bool isTest;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTest)
        {
            StartCoroutine(Test());
        }

        /* angle = Random.Range(0f, 360f);
        posX = transform.position.x + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        posZ = transform.position.z + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        transform.GetChild(0).position = new Vector3(posX, transform.position.y, posZ); */
    }

    IEnumerator Test()
    {
        isTest = true;
        yield return new WaitForSeconds(0.1f);
        angle = Random.Range(0f, 360f);
        radiusX = Random.Range(5, 10);
        radiusZ = Random.Range(5, 10);
        posX = transform.position.x + radiusX * Mathf.Cos(angle * Mathf.Deg2Rad);
        posZ = transform.position.z + radiusZ * Mathf.Sin(angle * Mathf.Deg2Rad);
        transform.GetChild(0).position = new Vector3(posX, transform.position.y, posZ);
        isTest = false;

    }
}
