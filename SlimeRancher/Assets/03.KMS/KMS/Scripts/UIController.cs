using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private void Start()
    {
        Set();
        #region Button Assign
        // Main
        UIManager.Instance.btn_Play_.onClick.AddListener(() => UIManager.Instance.GamePlay());
        UIManager.Instance.btn_Load_.onClick.AddListener(() => UIManager.Instance.GameLoad());
        UIManager.Instance.btn_Option_.onClick.AddListener(() => UIManager.Instance.GameOption());
        UIManager.Instance.btn_Exit_.onClick.AddListener(() => UIManager.Instance.GameExit());

        // Play
        UIManager.Instance.btn_PlayExit_.onClick.AddListener(() => UIManager.Instance.Exit_PlayMenu());

        // Load
        UIManager.Instance.btn_LoadExit_.onClick.AddListener(() => UIManager.Instance.Exit_LoadMenu());

        // Option
        UIManager.Instance.btn_GraphicOption_.onClick.AddListener(() => UIManager.Instance.GraphicOption_Btn());
        UIManager.Instance.btn_SoundOption_.onClick.AddListener(() => UIManager.Instance.SoundOption_Btn());
        UIManager.Instance.btn_GamePlayOption_.onClick.AddListener(() => UIManager.Instance.GamePlayOption_Btn());
        UIManager.Instance.btn_GamePadOption_.onClick.AddListener(() => UIManager.Instance.GamePadOption_Btn());
        UIManager.Instance.btn_EtcOption_.onClick.AddListener(() => UIManager.Instance.EtcOption_Btn());
        UIManager.Instance.btn_optionExit_.onClick.AddListener(() => UIManager.Instance.Exit_GameOption());

        // test
        UIManager.Instance.btn_TestPlay_.onClick.AddListener(() => SceneManager_.Instance.GoPlayScene());

        //Graphics test
        UIManager.Instance.btn_FullScreen_.onClick.AddListener(
            () => UIManager.Instance.FullScreen_Btn()
        );
        UIManager.Instance.btn_Star_.onClick.AddListener(
            () => UIManager.Instance.Star_Btn()
        );
        UIManager.Instance.btn_Cloud_.onClick.AddListener(
            () => UIManager.Instance.Cloud_Btn()
        );
        UIManager.Instance.btn_Shadow_.onClick.AddListener(
            () => UIManager.Instance.Shadow_Btn()
        );
        UIManager.Instance.btn_LightIMP_.onClick.AddListener(
            () => UIManager.Instance.Light_IMP_Btn()
        );
        UIManager.Instance.btn_WaterIMP_.onClick.AddListener(
            () => UIManager.Instance.Water_IMP_Btn()
        );
        #endregion
    }

    private void Update()
    {
        ExitKeys();
    }

    private void ExitKeys()
    {
        // Play
        UIManager.Instance.Exit_PlayMenu_Key();

        // Load
        UIManager.Instance.Exit_LoadMenu_Key();

        // Option
        UIManager.Instance.Exit_GameOption_Key();
    }

    private void Set()
    {
        UIManager.Instance.Create();

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
