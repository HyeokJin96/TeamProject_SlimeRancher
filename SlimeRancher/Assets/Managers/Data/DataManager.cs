using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : KSingleton<DataManager>
{
    public PlayerData playerData_ = new PlayerData();
    string path = default;
    string fileName = "p_Data.json";

    public bool isLoad = default;

    public override void Init()
    {
        path = Application.persistentDataPath + "/";
    }

    public void SaveData()
    {
        string p_Data = JsonUtility.ToJson(playerData_);
        File.WriteAllText(path + fileName, p_Data);
        Debug.Log("Save");
    }

    public void LoadData()
    {
        string p_Data = File.ReadAllText(path + fileName);
        playerData_ = JsonUtility.FromJson<PlayerData>(p_Data);
        Debug.Log("Load");
    }

    public void SetPlayerData()
    {
        playerData_.SetPos();
        playerData_.SetRot();
        Debug.Log("Load_Complete");
    }

    public void GetPlayerData()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Save?");
            playerData_.GetPos();
            playerData_.GetRot();
        }
    }
}
