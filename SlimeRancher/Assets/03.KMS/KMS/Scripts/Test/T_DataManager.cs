using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerData_
{
    public string slotName = default;
    public Vector3 playerPos_ = default;
    public Quaternion playerRot_ = default;
}

public class T_DataManager : KSingleton<T_DataManager>
{
    public PlayerData_ playerdata_ = new PlayerData_();

    public string path = default;

    public bool isLoadOn = false;

    public override void Awake()
    {
        base.Awake();
        path = Application.persistentDataPath + "/p_Data.json";
        Debug.Log(path);
    }
    public override void Start()
    {
        base.Start();
    }

    public void SaveData_P()
    {
        string data = JsonUtility.ToJson(playerdata_);
        File.WriteAllText(path, data);
    }

    public void LoadData_P()
    {
        string data = File.ReadAllText(path);
        playerdata_ = JsonUtility.FromJson<PlayerData_>(data);
    }

    public void DataClear()
    {
        playerdata_ = new PlayerData_();
    }
}
