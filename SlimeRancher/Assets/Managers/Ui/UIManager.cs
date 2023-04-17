using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : KSingleton<UIManager>
{
    #region Variable Declaration
    [Header("Ui Objects")]
    //UiObjects
    public GameObject UiObjs = default;
    public GameObject buttons = default;

    //Play
    public GameObject PlayMenu = default;

    //Load
    public GameObject LoadMenu = default;

    //Option
    public GameObject optionMenu = default;
    public GameObject bg_GraphicOption = default;
    public GameObject bg_SoundOption = default;
    public GameObject bg_GamePlayOption = default;
    public GameObject bg_GamePadOption = default;
    public GameObject bg_EtcOption = default;

    //InGame
    public GameObject inGameMenu = default;

    [Header("Buttons")]
    //Main Buttons
    public GameObject btn_Play = default;
    public Button btn_Play_ = default;
    public GameObject btn_Load = default;
    public Button btn_Load_ = default;
    public GameObject btn_Option = default;
    public Button btn_Option_ = default;
    public GameObject btn_Exit = default;
    public Button btn_Exit_ = default;

    //Play Buttons
    public GameObject btn_PlayExit = default;
    public Button btn_PlayExit_ = default;

    public GameObject btn_TestPlay = default; // test
    public Button btn_TestPlay_ = default; // test

    //Load Buttons
    public GameObject btn_LoadExit = default;
    public Button btn_LoadExit_ = default;

    //Option Buttons
    public GameObject btn_optionExit = default;
    public Button btn_optionExit_ = default;
    public GameObject btn_GraphicOption = default;
    public Button btn_GraphicOption_ = default;
    public GameObject btn_SoundOption = default;
    public Button btn_SoundOption_ = default;
    public GameObject btn_GamePlayOption = default;
    public Button btn_GamePlayOption_ = default;
    public GameObject btn_GamePadOption = default;
    public Button btn_GamePadOption_ = default;
    public GameObject btn_EtcOption = default;
    public Button btn_EtcOption_ = default;

    //InGame Button
    public GameObject btn_Resume = default;
    public Button btn_Resume_ = default;

    public GameObject btn_IGOption = default;
    public Button btn_IGOption_ = default;
    public GameObject btn_IGOptionExit = default;
    public Button btn_IGOptionExit_ = default;

    public GameObject btn_ScreenShot = default;
    public Button btn_ScreenShot_ = default;

    public GameObject btn_SaveExit = default;
    public Button btn_SaveExit_ = default;


    [Header("Open Check")]
    //Open Check Main
    public bool isOptionMenu_Open = false;
    public bool isLoadMenu_Open = false;
    public bool isPlayMenu_Open = false;

    //Open Check Option
    public bool isGraphicOp_Open = false;
    public bool isSoundOp_Open = false;
    public bool isGamePlayOp_Open = false;
    public bool isGamePadOp_Open = false;
    public bool isEtcOp_Open = false;

    //Open Check InGame
    public bool isInGameMenu_Open = false;
    #endregion

    public override void Init()
    {
        //Caching
        UiObjs = GameObject.Find("UiObjs").gameObject;
        buttons = UiObjs.transform.GetChild(1).gameObject;

        #region Main Objects
        PlayMenu = UiObjs.transform.GetChild(4).gameObject;
        LoadMenu = UiObjs.transform.GetChild(3).gameObject;
        optionMenu = UiObjs.transform.GetChild(2).gameObject;

        btn_Play = buttons.transform.GetChild(0).gameObject;
        btn_Play_ = btn_Play.GetComponent<Button>();
        btn_Load = buttons.transform.GetChild(1).gameObject;
        btn_Load_ = btn_Load.GetComponent<Button>();
        btn_Option = buttons.transform.GetChild(2).gameObject;
        btn_Option_ = btn_Option.GetComponent<Button>();
        btn_Exit = buttons.transform.GetChild(3).gameObject;
        btn_Exit_ = btn_Exit.GetComponent<Button>();
        #endregion

        #region PlayMenu Objects
        btn_PlayExit = PlayMenu.transform.GetChild(4).gameObject;
        btn_PlayExit_ = btn_PlayExit.GetComponent<Button>();
        #endregion

        #region LoadMenu Objects
        btn_LoadExit = LoadMenu.transform.GetChild(4).gameObject;
        btn_LoadExit_ = btn_LoadExit.GetComponent<Button>();
        #endregion

        #region OptionMenu Objects
        bg_GraphicOption = optionMenu.transform.GetChild(4).gameObject;
        bg_SoundOption = optionMenu.transform.GetChild(6).gameObject;
        bg_GamePlayOption = optionMenu.transform.GetChild(8).gameObject;
        bg_GamePadOption = optionMenu.transform.GetChild(10).gameObject;
        bg_EtcOption = optionMenu.transform.GetChild(12).gameObject;

        btn_GraphicOption = optionMenu.transform.GetChild(3).gameObject;
        btn_GraphicOption_ = btn_GraphicOption.GetComponent<Button>();
        btn_SoundOption = optionMenu.transform.GetChild(5).gameObject;
        btn_SoundOption_ = btn_SoundOption.GetComponent<Button>();
        btn_GamePlayOption = optionMenu.transform.GetChild(7).gameObject;
        btn_GamePlayOption_ = btn_GamePlayOption.GetComponent<Button>();
        btn_GamePadOption = optionMenu.transform.GetChild(9).gameObject;
        btn_GamePadOption_ = btn_GamePadOption.GetComponent<Button>();
        btn_EtcOption = optionMenu.transform.GetChild(11).gameObject;
        btn_EtcOption_ = btn_EtcOption.GetComponent<Button>();
        btn_optionExit = optionMenu.transform.GetChild(13).gameObject;
        btn_optionExit_ = btn_optionExit.GetComponent<Button>();
        #endregion

        #region InGameMenu Objects
        inGameMenu = UiObjs.transform.GetChild(5).gameObject;
        btn_Resume = inGameMenu.transform.GetChild(0).gameObject;
        btn_Resume_ = btn_Resume.GetComponent<Button>();

        btn_IGOption = inGameMenu.transform.GetChild(3).gameObject;
        btn_IGOption_ = btn_IGOption.GetComponent<Button>();
        btn_IGOptionExit = optionMenu.transform.GetChild(13).gameObject;
        btn_IGOptionExit_ = btn_IGOptionExit.GetComponent<Button>();

        btn_ScreenShot = inGameMenu.transform.GetChild(4).gameObject;
        btn_ScreenShot_ = btn_ScreenShot.GetComponent<Button>();

        btn_SaveExit = inGameMenu.transform.GetChild(6).gameObject;
        btn_SaveExit_ = btn_SaveExit.GetComponent<Button>();

        #endregion

        //Test Button
        btn_TestPlay = PlayMenu.transform.GetChild(5).gameObject;
        btn_TestPlay_ = btn_TestPlay.GetComponent<Button>();
        //Test Button
    }

    #region Play Button Function
    public void GamePlay()
    {
        PlayMenu.SetActive(true);
        buttons.SetActive(false);
        isPlayMenu_Open = true;
    }

    public void Exit_PlayMenu()
    {
        PlayMenu.SetActive(false);
        buttons.SetActive(true);
        isPlayMenu_Open = false;
    }

    public void Exit_PlayMenu_Key()
    {
        if (isPlayMenu_Open == true && Input.GetKeyDown(KeyCode.Escape))
        {
            PlayMenu.SetActive(false);
            buttons.SetActive(true);
            isPlayMenu_Open = false;
        }
    }
    #endregion

    #region Load Button Function
    public void GameLoad()
    {
        LoadMenu.SetActive(true);
        buttons.SetActive(false);
        isLoadMenu_Open = true;
    }

    public void Exit_LoadMenu()
    {
        LoadMenu.SetActive(false);
        buttons.SetActive(true);
        isLoadMenu_Open = false;
    }

    public void Exit_LoadMenu_Key()
    {
        if (isLoadMenu_Open == true && Input.GetKeyDown(KeyCode.Escape))
        {
            LoadMenu.SetActive(false);
            buttons.SetActive(true);
            isLoadMenu_Open = false;
        }
    }
    #endregion

    #region Option Button Function
    public void GameOption()
    {
        optionMenu.SetActive(true);
        buttons.SetActive(false);
        isOptionMenu_Open = true;
    }

    public void Exit_GameOption()
    {
        optionMenu.SetActive(false);
        buttons.SetActive(true);

        //false else
        bg_GraphicOption.SetActive(false);
        bg_SoundOption.SetActive(false);
        bg_GamePlayOption.SetActive(false);
        bg_GamePadOption.SetActive(false);
        bg_EtcOption.SetActive(false);

        isGraphicOp_Open = false;
        isSoundOp_Open = false;
        isGamePlayOp_Open = false;
        isGamePadOp_Open = false;
        isEtcOp_Open = false;

        isOptionMenu_Open = false;
    }

    public void Exit_GameOption_Key()
    {
        if (isOptionMenu_Open == true && Input.GetKeyDown(KeyCode.Escape))
        {
            optionMenu.SetActive(false);
            buttons.SetActive(true);

            //false else
            bg_GraphicOption.SetActive(false);
            bg_SoundOption.SetActive(false);
            bg_GamePlayOption.SetActive(false);
            bg_GamePadOption.SetActive(false);
            bg_EtcOption.SetActive(false);

            isGraphicOp_Open = false;
            isSoundOp_Open = false;
            isGamePlayOp_Open = false;
            isGamePadOp_Open = false;
            isEtcOp_Open = false;

            isOptionMenu_Open = false;
        }
    }

    public void GraphicOption_Btn()
    {
        bg_GraphicOption.SetActive(true);
        isGraphicOp_Open = true;

        //false else
        bg_SoundOption.SetActive(false);
        isSoundOp_Open = false;

        bg_GamePlayOption.SetActive(false);
        isGamePlayOp_Open = false;

        bg_GamePadOption.SetActive(false);
        isGamePadOp_Open = false;

        bg_EtcOption.SetActive(false);
        isEtcOp_Open = false;
    }

    public void SoundOption_Btn()
    {
        bg_SoundOption.SetActive(true);
        isSoundOp_Open = true;

        //false else
        bg_GraphicOption.SetActive(false);
        isGraphicOp_Open = false;

        bg_GamePlayOption.SetActive(false);
        isGamePlayOp_Open = false;

        bg_GamePadOption.SetActive(false);
        isGamePadOp_Open = false;

        bg_EtcOption.SetActive(false);
        isEtcOp_Open = false;
    }

    public void GamePlayOption_Btn()
    {
        bg_GamePlayOption.SetActive(true);
        isGamePlayOp_Open = true;

        //false else
        bg_GraphicOption.SetActive(false);
        isGraphicOp_Open = false;

        bg_SoundOption.SetActive(false);
        isSoundOp_Open = false;

        bg_GamePadOption.SetActive(false);
        isGamePadOp_Open = false;

        bg_EtcOption.SetActive(false);
        isEtcOp_Open = false;
    }

    public void GamePadOption_Btn()
    {
        bg_GamePadOption.SetActive(true);
        isGamePadOp_Open = true;

        //false else
        bg_GraphicOption.SetActive(false);
        isGraphicOp_Open = false;

        bg_SoundOption.SetActive(false);
        isSoundOp_Open = false;

        bg_GamePlayOption.SetActive(false);
        isGamePlayOp_Open = false;

        bg_EtcOption.SetActive(false);
        isEtcOp_Open = false;
    }

    public void EtcOption_Btn()
    {
        bg_EtcOption.SetActive(true);
        isEtcOp_Open = true;

        //false else
        bg_GraphicOption.SetActive(false);
        isGraphicOp_Open = false;

        bg_SoundOption.SetActive(false);
        isSoundOp_Open = false;

        bg_GamePlayOption.SetActive(false);
        isGamePlayOp_Open = false;

        bg_GamePadOption.SetActive(false);
        isGamePadOp_Open = false;
    }
    #endregion

    #region Exit Button Function
    public void GameExit()
    {
        GFunc.QuitThisGame();
    }
    #endregion

    #region InGameMenu Button Function
    public void InGameMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isInGameMenu_Open = !isInGameMenu_Open;
            if (isInGameMenu_Open == true)
            {
                inGameMenu.SetActive(true);
                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            if (isInGameMenu_Open == false && isOptionMenu_Open == false)
            {
                inGameMenu.SetActive(false);
                Time.timeScale = 1;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    public void Resume_Btn()
    {
        isInGameMenu_Open = false;
        inGameMenu.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void IGOption_Btn()
    {
        optionMenu.SetActive(true);
        inGameMenu.SetActive(false);
        isOptionMenu_Open = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void IGOptionExit_Btn()
    {
        optionMenu.SetActive(false);
        inGameMenu.SetActive(true);

        //false else
        bg_GraphicOption.SetActive(false);
        bg_SoundOption.SetActive(false);
        bg_GamePlayOption.SetActive(false);
        bg_GamePadOption.SetActive(false);
        bg_EtcOption.SetActive(false);

        isGraphicOp_Open = false;
        isSoundOp_Open = false;
        isGamePlayOp_Open = false;
        isGamePadOp_Open = false;
        isEtcOp_Open = false;

        isOptionMenu_Open = false;
    }

    public void IGOptionExit_Key()
    {
        if (isOptionMenu_Open == true && Input.GetKeyDown(KeyCode.Escape))
        {
            optionMenu.SetActive(false);
            inGameMenu.SetActive(true);

            //false else
            bg_GraphicOption.SetActive(false);
            bg_SoundOption.SetActive(false);
            bg_GamePlayOption.SetActive(false);
            bg_GamePadOption.SetActive(false);
            bg_EtcOption.SetActive(false);

            isGraphicOp_Open = false;
            isSoundOp_Open = false;
            isGamePlayOp_Open = false;
            isGamePadOp_Open = false;
            isEtcOp_Open = false;

            isOptionMenu_Open = false;
        }
    }

    public void ScreenShot_Btn()
    {
        inGameMenu.SetActive(false);
        ScreenCapture.CaptureScreenshot($"ScreenShot{System.DateTime.Now.ToString("MMddHHmmss")}.png");
        StartCoroutine(DelayForSS());
    }
    private IEnumerator DelayForSS()
    {
        yield return null;
        inGameMenu.SetActive(true);
    }

    public void SaveExit_Btn()
    {
        //Save First
        isInGameMenu_Open = false;
        Time.timeScale = 1;
        SceneManager_.Instance.GoTitleScene();
    }
    #endregion
}
