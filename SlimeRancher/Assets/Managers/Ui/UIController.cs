using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private void Update()
    {
        UIManager.Instance.Exit_GameOption_Key();
        UIManager.Instance.Exit_LoadMenu_Key();
        UIManager.Instance.Exit_PlayMenu_Key();
    }
}
