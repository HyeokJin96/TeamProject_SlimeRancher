using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TestSlot : MonoBehaviour
{
    public Text slotText = default;

    public bool saveFile = default;


    void Start()
    {
        if (File.Exists(T_DataManager.Instance.path_P)
            && File.Exists(T_DataManager.Instance.path_T)
            && File.Exists(T_DataManager.Instance.path_OG))
        {
            saveFile = true;
            T_DataManager.Instance.LoadData_P();
            T_DataManager.Instance.LoadData_T();
            T_DataManager.Instance.LoadData_OG();
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
            T_DataManager.Instance.LoadData_T();
            T_DataManager.Instance.LoadData_OG();
            T_DataManager.Instance.isLoadOn = true;
            GoPlayScene_();
        }
        else
        {
            /*Do Nothing*/
        }
    }

    public void GoPlayScene_()
    {
        if (saveFile == false)
        {
            T_DataManager.Instance.SaveData_P();
            T_DataManager.Instance.SaveData_T();
            T_DataManager.Instance.SaveData_OG();
        }
        SceneManager_.Instance.GoPlayScene();
    }
}
