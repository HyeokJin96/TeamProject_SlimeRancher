using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : KSingleton<UIManager>
{
    private GameObject UiObjs = default;
    private GameObject buttons = default;

    private GameObject optionMenu = default;
    private GameObject btn_optionExit = default;
    private Button btn_optionExit_ = default;

    private GameObject btn_Option = default;
    private Button btn_Option_ = default;

    private GameObject btn_Exit = default;
    private Button btn_Exit_ = default;

    private void Start()
    {
        UiObjs = GameObject.Find("UiObjs_Title").gameObject;
        
        buttons = UiObjs.transform.GetChild(1).gameObject;
        optionMenu = UiObjs.transform.GetChild(2).gameObject;

        btn_optionExit = optionMenu.transform.GetChild(10).gameObject;
        btn_optionExit_ = btn_optionExit.GetComponent<Button>();

        btn_Option = buttons.transform.GetChild(2).gameObject;
        btn_Option_ = btn_Option.GetComponent<Button>();

        btn_Exit = buttons.transform.GetChild(3).gameObject;
        btn_Exit_ = btn_Exit.GetComponent<Button>();

        btn_optionExit_.onClick.AddListener(() => Exit_GameOption());
        btn_Option_.onClick.AddListener(() => GameOption());
        btn_Exit_.onClick.AddListener(() => GameExit());
    }

    public void GameExit()
    {
        GFunc.QuitThisGame();
    }

    public void GameOption()
    {
        optionMenu.SetActive(true);
        buttons.SetActive(false);
    }
    public void Exit_GameOption()
    {
        optionMenu.SetActive(false);
        buttons.SetActive(true);
    }
}
