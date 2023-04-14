using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : KSingleton<UIManager>
{
    [Header("Ui Objects")]
    //UiObjects
    public GameObject UiObjs = default;
    public GameObject buttons = default;
    public GameObject optionMenu = default;
    public GameObject LoadMenu = default;
    public GameObject PlayMenu = default;

    //Option Menu Background
    public GameObject bg_GraphicOption = default;
    public GameObject bg_SoundOption = default;
    public GameObject bg_GamePlayOption = default;
    public GameObject bg_GamePadOption = default;
    public GameObject bg_EtcOption = default;

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

    private new void Awake()
    {
        //Cashing
        UiObjs = GameObject.Find("UiObjs_Title").gameObject;
        buttons = UiObjs.transform.GetChild(1).gameObject;
        optionMenu = UiObjs.transform.GetChild(2).gameObject;
        LoadMenu = UiObjs.transform.GetChild(3).gameObject;
        PlayMenu = UiObjs.transform.GetChild(4).gameObject;

        //Test Button
        btn_TestPlay = PlayMenu.transform.GetChild(5).gameObject;
        btn_TestPlay_ = btn_TestPlay.GetComponent<Button>();
        btn_TestPlay_.onClick.AddListener(() => SceneManager_.Instance.GoPlayScene());
        //Test Button

        #region Main Buttons
        btn_Play = buttons.transform.GetChild(0).gameObject;
        btn_Play_ = btn_Play.GetComponent<Button>();
        btn_Load = buttons.transform.GetChild(1).gameObject;
        btn_Load_ = btn_Load.GetComponent<Button>();
        btn_Option = buttons.transform.GetChild(2).gameObject;
        btn_Option_ = btn_Option.GetComponent<Button>();
        btn_Exit = buttons.transform.GetChild(3).gameObject;
        btn_Exit_ = btn_Exit.GetComponent<Button>();


        btn_Play_.onClick.AddListener(() => GamePlay());
        btn_Load_.onClick.AddListener(() => GameLoad());
        btn_Option_.onClick.AddListener(() => GameOption());
        btn_Exit_.onClick.AddListener(() => GameExit());
        #endregion

        #region PlayMenu Objects
        btn_PlayExit = PlayMenu.transform.GetChild(4).gameObject;
        btn_PlayExit_ = btn_PlayExit.GetComponent<Button>();

        btn_PlayExit_.onClick.AddListener(() => Exit_PlayMenu());
        #endregion

        #region LoadMenu Objects
        btn_LoadExit = LoadMenu.transform.GetChild(4).gameObject;
        btn_LoadExit_ = btn_LoadExit.GetComponent<Button>();

        btn_LoadExit_.onClick.AddListener(() => Exit_LoadMenu());
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

        btn_GraphicOption_.onClick.AddListener(() => GraphicOption_Btn());
        btn_SoundOption_.onClick.AddListener(() => SoundOption_Btn());
        btn_GamePlayOption_.onClick.AddListener(() => GamePlayOption_Btn());
        btn_GamePadOption_.onClick.AddListener(() => GamePadOption_Btn());
        btn_EtcOption_.onClick.AddListener(() => EtcOption_Btn());
        btn_optionExit_.onClick.AddListener(() => Exit_GameOption());
        #endregion
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
}
