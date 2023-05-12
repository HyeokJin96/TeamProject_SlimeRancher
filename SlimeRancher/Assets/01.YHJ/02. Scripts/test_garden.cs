using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_garden : MonoBehaviour
{
    [SerializeField] private ObjecData objectData = default;
    [SerializeField] private GameObject display = default;

    [SerializeField] private Material none = default;
    [SerializeField] private Material carrot = default;
    [SerializeField] private Material heartbeet = default;
    [SerializeField] private Material ocaoca = default;
    [SerializeField] private Material cuberry = default;

    public bool isCarrot = false;
    public bool isHeartbeet = false;
    public bool isOcaOca = false;
    public bool isCuberry = false;

    public void OnTriggerEnter(Collider other)
    {
        objectData = other.transform.parent.GetComponent<ObjecData>();

        if (objectData != null)
        {
            switch (objectData.foodName)
            {
                case FoodName.Carrot:
                    display.GetComponent<MeshRenderer>().material = carrot;

                    isCarrot = true;
                    isHeartbeet = false;
                    isOcaOca = false;
                    isCuberry = false;
                    break;
                case FoodName.Heartbeet:
                    display.GetComponent<MeshRenderer>().material = heartbeet;

                    isCarrot = false;
                    isHeartbeet = true;
                    isOcaOca = false;
                    isCuberry = false;
                    break;
                case FoodName.OcaOca:
                    display.GetComponent<MeshRenderer>().material = ocaoca;

                    isCarrot = false;
                    isHeartbeet = false;
                    isOcaOca = true;
                    isCuberry = false;
                    break;
                case FoodName.Cuberry:
                    display.GetComponent<MeshRenderer>().material = cuberry;

                    isCarrot = false;
                    isHeartbeet = false;
                    isOcaOca = false;
                    isCuberry = true;
                    break;
            }
            other.gameObject.SetActive(false);
        }

    }
}
