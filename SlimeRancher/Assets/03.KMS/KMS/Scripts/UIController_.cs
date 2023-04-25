using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController_ : MonoBehaviour
{
    private void Start()
    {
        Set();
        #region Button Assign
        //InGame
        UIManager.Instance.btn_Resume_.onClick.AddListener(() => UIManager.Instance.Resume_Btn());
        UIManager.Instance.btn_SaveExit_.onClick.AddListener(
            () => UIManager.Instance.SaveExit_Btn()
        );

        //Option
        UIManager.Instance.btn_IGOption_.onClick.AddListener(
            () => UIManager.Instance.IGOption_Btn()
        );
        UIManager.Instance.btn_IGOptionExit_.onClick.AddListener(
            () => UIManager.Instance.IGOptionExit_Btn()
        );

        //Graphics
        UIManager.Instance.btn_FullScreen_.onClick.AddListener(
            () => UIManager.Instance.FullScreen_Btn()
        );
        UIManager.Instance.btn_Star_.onClick.AddListener(() => UIManager.Instance.Star_Btn());
        UIManager.Instance.btn_Cloud_.onClick.AddListener(() => UIManager.Instance.Cloud_Btn());
        UIManager.Instance.btn_Shadow_.onClick.AddListener(() => UIManager.Instance.Shadow_Btn());
        UIManager.Instance.btn_LightIMP_.onClick.AddListener(
            () => UIManager.Instance.Light_IMP_Btn()
        );
        UIManager.Instance.btn_WaterIMP_.onClick.AddListener(
            () => UIManager.Instance.Water_IMP_Btn()
        );

        //ScreenShot
        UIManager.Instance.btn_ScreenShot_.onClick.AddListener(
            () => UIManager.Instance.ScreenShot_Btn()
        );

        //Take TitleScene Option
        UIManager.Instance.btn_GraphicOption_.onClick.AddListener(
            () => UIManager.Instance.GraphicOption_Btn()
        );
        UIManager.Instance.btn_SoundOption_.onClick.AddListener(
            () => UIManager.Instance.SoundOption_Btn()
        );
        UIManager.Instance.btn_GamePlayOption_.onClick.AddListener(
            () => UIManager.Instance.GamePlayOption_Btn()
        );
        UIManager.Instance.btn_GamePadOption_.onClick.AddListener(
            () => UIManager.Instance.GamePadOption_Btn()
        );
        UIManager.Instance.btn_EtcOption_.onClick.AddListener(
            () => UIManager.Instance.EtcOption_Btn()
        );
        #endregion
    }

    private void Update()
    {
        // InGame
        UIManager.Instance.InGameMenu();
        UIManager.Instance.MapOpen();

        //Option
        UIManager.Instance.IGOptionExit_Key();
    }

    private void Set()
    {
        UIManager.Instance.Create();
        GameManager.Instance.Create();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    
}
