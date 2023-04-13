using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : KSingleton<DataManager>
{
    PlayerData playerData_ = new PlayerData();
    string path = default;
    string fileName = "p_Data.json";

    private new void Awake()
    {
        path = Application.persistentDataPath + "/";
    }

    public void SaveData()
    {
        string p_Data = JsonUtility.ToJson(playerData_);
        Debug.Log(p_Data);
        File.WriteAllText(path + fileName, p_Data);
    }

    public void LoadData()
    {
        string p_Data = File.ReadAllText(path + fileName);
        playerData_ = JsonUtility.FromJson<PlayerData>(p_Data);

        playerData_.SetPos();
        playerData_.SetRot();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            playerData_.GetPos();
            playerData_.GetRot();
            Debug.Log("Ready");
        }
    }
}
