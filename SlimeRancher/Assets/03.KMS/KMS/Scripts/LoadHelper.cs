using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadHelper : MonoBehaviour
{
    void Start()
    {
        if (DataManager.Instance.isLoad)
        {
            DataManager.Instance.LoadData();
            DataManager.Instance.SetPlayerData();
        }
    }
}
