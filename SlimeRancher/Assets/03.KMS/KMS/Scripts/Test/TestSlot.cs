using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TestSlot : MonoBehaviour
{
    public GameObject newGameMenu = default;
    public Text slotText = default;

    public bool saveFile = default;


    void Start()
    {
        if (File.Exists(T_DataManager.Instance.path))
        {
            saveFile = true;
            T_DataManager.Instance.LoadData_P();
            slotText.text = $"Play";
        }
        else
        {
            slotText.text = "Empty";
        }

        T_DataManager.Instance.DataClear();
    }
    public void SaveSlot()
    {
        if (saveFile == true)
        {
            T_DataManager.Instance.LoadData_P();
            T_DataManager.Instance.isLoadOn = true;
            GoPlayScene_();
        }
        else
        {
            NewGame();
        }
    }

    public void NewGame()
    {
        newGameMenu.SetActive(true);
    }

    public void GoPlayScene_()
    {
        if (saveFile == false)
        {
            T_DataManager.Instance.SaveData_P();
        }
        SceneManager_.Instance.GoPlayScene();
    }
}
