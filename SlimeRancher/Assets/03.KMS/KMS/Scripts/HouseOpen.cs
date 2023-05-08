using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseOpen : MonoBehaviour
{
    public GameObject houseUI = default;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            GameManager.Instance.isInHouse = true;
        }
        else
        {
            /*Do Nothing*/
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.isInHouse = false;
        }
    }

    private void Update()
    {
        if (GameManager.Instance.isInHouse == true)
        {
            TimeController.Instance.NTimesFaster0();
            houseUI.SetActive(true);
        }
        else
        {
            TimeController.Instance.NTimesFaster1();
            houseUI.SetActive(false);
        }
    }
}
