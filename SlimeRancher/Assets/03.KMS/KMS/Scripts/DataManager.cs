using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    private static DataManager instance;

    PlayerData playerData_ = new PlayerData();
    string path = default;
    string fileName = "p_Data.json";

    public static DataManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DataManager>();
                if (instance == null)
                {
                    instance = new GameObject("DataManager").AddComponent<DataManager>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

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
