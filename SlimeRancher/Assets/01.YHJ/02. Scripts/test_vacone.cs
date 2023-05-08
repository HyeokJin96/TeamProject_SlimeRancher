using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_vacone : MonoBehaviour
{
    [SerializeField] private GameObject[] ring_FX = new GameObject[8];

    [SerializeField] private float rotateSpeed;

    private void Update()
    {
        for (int i = 0; i < ring_FX.Length; i++)
        {
            ring_FX[i].transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
        }
    }
}
