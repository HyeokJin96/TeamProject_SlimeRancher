using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class T_DataManager : KSingleton<T_DataManager>
{
    public PlayerData_ playerdata_ = new PlayerData_();
    public TimeData_ timedata_ = new TimeData_();
    public EnvironmentData_ en_Data_ = new EnvironmentData_();

    public string path_P = default;
    public string path_T = default;
    public string path_OG = default;

    public bool isLoadOn = false;

    public override void Awake()
    {
        base.Awake();

        path_P = Application.persistentDataPath + "/p_Data.json";
        path_T = Application.persistentDataPath + "/t_Data.json";
        path_OG = Application.persistentDataPath + "/og_Data.json";
    }

    public override void Start()
    {
        base.Start();
    }

    //player
    public void SaveData_P()
    {
        string data = JsonUtility.ToJson(playerdata_);
        File.WriteAllText(path_P, data);
    }

    public void LoadData_P()
    {
        string data = File.ReadAllText(path_P);
        playerdata_ = JsonUtility.FromJson<PlayerData_>(data);
    }

    //time
    public void SaveData_T()
    {
        string data = JsonUtility.ToJson(timedata_);
        File.WriteAllText(path_T, data);
    }

    public void LoadData_T()
    {
        string data = File.ReadAllText(path_T);
        timedata_ = JsonUtility.FromJson<TimeData_>(data);
    }

    //graphics
    public void SaveData_OG()
    {
        string data = JsonUtility.ToJson(en_Data_);
        File.WriteAllText(path_OG, data);
    }

    public void LoadData_OG()
    {
        string data = File.ReadAllText(path_OG);
        en_Data_ = JsonUtility.FromJson<EnvironmentData_>(data);
    }


    public void DataClear()
    {
        playerdata_ = new PlayerData_();
        timedata_ = new TimeData_();
        en_Data_ = new EnvironmentData_();
    }
}
