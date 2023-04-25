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
    public GameObject map = default;

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
    public GameObject playerUI = default;

    public GameObject inGameDay_Text = default;
    public Text inGameDay_Text_ = default;
    public GameObject inGameTime_Text = default;
    public Text inGameTime_Text_ = default;

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

    public GameObject btn_TestLoad = default; // test
    public Button btn_TestLoad_ = default; // test

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

    //Option Graphics
    public GameObject text_FullScreen = default;
    public GameObject text_Star = default;
    public GameObject text_Cloud = default;
    public GameObject text_Shadow = default;
    public GameObject text_LightIMP = default;
    public GameObject text_WaterIMP = default;

    public GameObject btn_FullScreen = default;
    public Button btn_FullScreen_ = default;
    public GameObject btn_Star = default;
    public Button btn_Star_ = default;
    public GameObject btn_Cloud = default;
    public Button btn_Cloud_ = default;
    public GameObject btn_Shadow = default;
    public Button btn_Shadow_ = default;
    public GameObject btn_LightIMP = default;
    public Button btn_LightIMP_ = default;
    public GameObject btn_WaterIMP = default;
    public Button btn_WaterIMP_ = default;

    public GameObject Img_Check_F = default;
    public GameObject Img_Check_ST = default;
    public GameObject Img_Check_C = default;
    public GameObject Img_Check_SH = default;
    public GameObject Img_Check_L = default;
    public GameObject Img_Check_W = default;

    //InGame Button
    public GameObject btn_Resume = default;
    public Button btn_Resume_ = default;

    public GameObject btn_IGOption = default;
    public Button btn_IGOption_ = default;
    public GameObject btn_IGOptionExit = default;
    public Button btn_IGOptionExit_ = default;

    public GameObject btn_ScreenShot = default;
    public Button btn_ScreenShot_ = default;

    public GameObject btn_SaveExit = default; //test
    public Button btn_SaveExit_ = default; //test

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
    public bool isMapOpen = false;
    #endregion

    public override void Init()
    {
        //Caching
        UiObjs = GameObject.Find("UiObjs").gameObject;
        buttons = UiObjs.transform.GetChild(2).gameObject;

        #region Main Objects
        PlayMenu = UiObjs.transform.GetChild(5).gameObject;
        LoadMenu = UiObjs.transform.GetChild(4).gameObject;
        optionMenu = UiObjs.transform.GetChild(3).gameObject;

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

        //Graphics
        btn_GraphicOption = optionMenu.transform.GetChild(3).gameObject;
        btn_GraphicOption_ = btn_GraphicOption.GetComponent<Button>();

        text_FullScreen = bg_GraphicOption.transform.GetChild(3).gameObject;
        Img_Check_F = text_FullScreen.transform.GetChild(1).gameObject;
        btn_FullScreen = text_FullScreen.transform.GetChild(2).gameObject;
        btn_FullScreen_ = btn_FullScreen.GetComponent<Button>();

        text_Star = bg_GraphicOption.transform.GetChild(4).gameObject;
        Img_Check_ST = text_Star.transform.GetChild(1).gameObject;
        btn_Star = text_Star.transform.GetChild(2).gameObject;
        btn_Star_ = btn_Star.GetComponent<Button>();

        text_Cloud = bg_GraphicOption.transform.GetChild(5).gameObject;
        Img_Check_C = text_Cloud.transform.GetChild(1).gameObject;
        btn_Cloud = text_Cloud.transform.GetChild(2).gameObject;
        btn_Cloud_ = btn_Cloud.GetComponent<Button>();

        text_Shadow = bg_GraphicOption.transform.GetChild(6).gameObject;
        Img_Check_SH = text_Shadow.transform.GetChild(1).gameObject;
        btn_Shadow = text_Shadow.transform.GetChild(2).gameObject;
        btn_Shadow_ = btn_Shadow.GetComponent<Button>();

        text_LightIMP = bg_GraphicOption.transform.GetChild(7).gameObject;
        Img_Check_L = text_LightIMP.transform.GetChild(1).gameObject;
        btn_LightIMP = text_LightIMP.transform.GetChild(2).gameObject;
        btn_LightIMP_ = btn_LightIMP.GetComponent<Button>();

        text_WaterIMP = bg_GraphicOption.transform.GetChild(8).gameObject;
        Img_Check_W = text_WaterIMP.transform.GetChild(1).gameObject;
        btn_WaterIMP = text_WaterIMP.transform.GetChild(2).gameObject;
        btn_WaterIMP_ = btn_WaterIMP.GetComponent<Button>();

        //Sounds
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
        inGameMenu = UiObjs.transform.GetChild(6).gameObject;
        playerUI = UiObjs.transform.GetChild(0).gameObject;
        map = UiObjs.transform.GetChild(8).gameObject;

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

        #region InGameTime Texts
        inGameDay_Text = UiObjs.transform.GetChild(7).gameObject;
        inGameDay_Text_ = inGameDay_Text.GetComponent<Text>();

        inGameTime_Text = inGameDay_Text.transform.GetChild(0).gameObject;
        inGameTime_Text_ = inGameTime_Text.GetComponent<Text>();
        #endregion

        //Test Button
        btn_TestPlay = PlayMenu.transform.GetChild(5).gameObject;
        btn_TestPlay_ = btn_TestPlay.GetComponent<Button>();

        // btn_TestLoad = LoadMenu.transform.GetChild(5).gameObject;
        // btn_TestLoad_ = btn_TestLoad.GetComponent<Button>();
        //Test Button
    }

    #region Play Button Function
    public void GamePlay()
    {
        PlayMenu.SetActive(true);
        buttons.SetActive(false);
        isPlayMenu_Open = true;
        T_DataManager.Instance.isLoadOn = false;
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

    public void LoadPlayerData_Btn()
    {
        T_DataManager.Instance.isLoadOn = true;
        SceneManager_.Instance.GoPlayScene();
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

        T_DataManager.Instance.en_Data_.isFullScreenOn = GameManager.Instance.isFullScreenOn;
        T_DataManager.Instance.en_Data_.isStarOn = GameManager.Instance.isStarOn;
        T_DataManager.Instance.en_Data_.isCloudOn = GameManager.Instance.isCloudOn;
        T_DataManager.Instance.en_Data_.isShadowOn = GameManager.Instance.isShadowOn;
        T_DataManager.Instance.en_Data_.isLightImprovement = GameManager
            .Instance
            .isLightImprovement;
        T_DataManager.Instance.en_Data_.isWaterImprovement = GameManager
            .Instance
            .isWaterImprovement;
        T_DataManager.Instance.SaveData_OG();

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

            T_DataManager.Instance.en_Data_.isFullScreenOn = GameManager.Instance.isFullScreenOn;
            T_DataManager.Instance.en_Data_.isStarOn = GameManager.Instance.isStarOn;
            T_DataManager.Instance.en_Data_.isCloudOn = GameManager.Instance.isCloudOn;
            T_DataManager.Instance.en_Data_.isShadowOn = GameManager.Instance.isShadowOn;
            T_DataManager.Instance.en_Data_.isLightImprovement = GameManager
                .Instance
                .isLightImprovement;
            T_DataManager.Instance.en_Data_.isWaterImprovement = GameManager
                .Instance
                .isWaterImprovement;
            T_DataManager.Instance.SaveData_OG();

            isOptionMenu_Open = false;
        }
    }

    //Graphics
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

    public void FullScreen_Btn()
    {
        GameManager.Instance.FullScreenOn();
        T_DataManager.Instance.en_Data_.isFullScreenOn = GameManager.Instance.isFullScreenOn;
        // T_DataManager.Instance.SaveData_OG();
    }

    public void Star_Btn()
    {
        GameManager.Instance.StarOn();
        T_DataManager.Instance.en_Data_.isStarOn = GameManager.Instance.isStarOn;
        // T_DataManager.Instance.SaveData_OG();
    }

    public void Cloud_Btn()
    {
        GameManager.Instance.CloudOn();
        T_DataManager.Instance.en_Data_.isCloudOn = GameManager.Instance.isCloudOn;
        // T_DataManager.Instance.SaveData_OG();
    }

    public void Shadow_Btn()
    {
        GameManager.Instance.ShadowOn();
        T_DataManager.Instance.en_Data_.isShadowOn = GameManager.Instance.isShadowOn;
        // T_DataManager.Instance.SaveData_OG();
    }

    public void Light_IMP_Btn()
    {
        GameManager.Instance.LightQuality();
        T_DataManager.Instance.en_Data_.isLightImprovement = GameManager.Instance.isLightImprovement;
        // T_DataManager.Instance.SaveData_OG();
    }

    public void Water_IMP_Btn()
    {
        GameManager.Instance.WaterOn();
        T_DataManager.Instance.en_Data_.isWaterImprovement = GameManager.Instance.isWaterImprovement;
        // T_DataManager.Instance.SaveData_OG();
    }

    //Sounds
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
            if (isInGameMenu_Open == true && isMapOpen == false)
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
        inGameDay_Text.SetActive(false);
        playerUI.SetActive(false);
        ScreenCapture.CaptureScreenshot(
            $"ScreenShot{System.DateTime.Now.ToString("MMddHHmmss")}.png"
        );
        StartCoroutine(DelayForSS());
    }

    private IEnumerator DelayForSS()
    {
        yield return null;
        inGameMenu.SetActive(true);
        inGameDay_Text.SetActive(true);
        playerUI.SetActive(true);
    }

    public void SaveExit_Btn()
    {
        //Save First
        Time.timeScale = 1;
        isInGameMenu_Open = false;
        T_DataManager.Instance.SaveData_P();
        T_DataManager.Instance.SaveData_T();
        T_DataManager.Instance.SaveData_OG();
        SceneManager_.Instance.GoTitleScene();
    }


    public void MapOpen()
    {
        if (Input.GetKeyDown(KeyCode.M) && isInGameMenu_Open == false)
        {
            isMapOpen = !isMapOpen;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isMapOpen = false;
        }

        if (isMapOpen == true)
        {
            map.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            map.SetActive(false);
            Time.timeScale = 1;
        }
    }
    #endregion
}
