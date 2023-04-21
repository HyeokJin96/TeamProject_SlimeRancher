using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController_ : MonoBehaviour
{
    float minute = 0;
    float minute_ = 0;
    float hour = 0;
    float hour_ = 0;
    int day = 1;

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

        hour = 6;
    }

    private void Update()
    {
        // InGame
        UIManager.Instance.InGameMenu();

        //Option
        UIManager.Instance.IGOptionExit_Key();

        Timer();

        DataManager.Instance.GetPlayerData();
    }

    private void Set()
    {
        UIManager.Instance.Create();
        GameManager.Instance.Create();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Timer()
    {
        minute += Time.deltaTime * 12;

        minute_ = Mathf.FloorToInt(minute % 60);
        hour_ = Mathf.FloorToInt(hour % 60);

        if (minute >= 60)
        {
            hour += 1;
            minute = 0;
        }

        if (hour >= 24)
        {
            hour = 0;
            day++;
        }

        // 초를 00, 01, 02와 같은 형태로 표시합니다.
        string minute_S = minute_.ToString("00");
        string hour_S = hour.ToString("00");

        UIManager.Instance.inGameTime_Text_.text = "  " + hour_S + " : " + minute_S;
        UIManager.Instance.inGameDay_Text_.text = "  Day : " + day;
    }
}
