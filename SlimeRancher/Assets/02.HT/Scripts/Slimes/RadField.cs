using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadField : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player Rad Gauge Increase");
        }
    }
}
