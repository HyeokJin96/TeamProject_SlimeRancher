using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_false : MonoBehaviour
{
    [SerializeField] private GameObject garden;
    [SerializeField] private GameObject corral;

    private void Awake() {
        
garden = this.transform.GetChild(5).gameObject;
corral = this.transform.GetChild(6).gameObject;

        garden.gameObject.SetActive(false);
        corral.gameObject.SetActive(false);

    }
}
