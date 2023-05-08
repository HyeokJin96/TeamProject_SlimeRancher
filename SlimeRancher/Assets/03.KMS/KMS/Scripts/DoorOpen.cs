using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public GameObject End = default;

    private void OnTriggerStay(Collider other)
    {
        if (
            other.tag == "Player"
            && GameManager.Instance.isHaveKey == true
            && Input.GetKeyDown(KeyCode.E)
        )
        {
            TimeController.Instance.NTimesFaster0();
            End.SetActive(true);
            Invoke("Delay", 2);
        }
    }

    public void Delay()
    {
        GFunc.QuitThisGame();
    }
}
