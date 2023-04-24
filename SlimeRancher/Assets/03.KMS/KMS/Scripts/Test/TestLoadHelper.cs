using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLoadHelper : KSingleton<TestLoadHelper>
{
    //player
    public Vector3 playerPos_ = default;
    public Quaternion playerRot_ = default;

    //time
    public float minute_ = 0;
    public float hour_ = 0;
    public int day_ = 1;

    //graphics setting
    public bool isCloudOn_ = true;
    public bool isStarOn_ = true;
    public bool isShadowOn_ = true;
    public bool isWaterHigh_ = true;
    public bool isLightImprovement_ = true;
    public bool isFullScreenOn_ = true;
    public int width_ = 1920;
    public int height_ = 1080;

    new void Awake()
    {
        if (T_DataManager.Instance.isLoadOn == true)
        {
            //player
            playerPos_ = T_DataManager.Instance.playerdata_.playerPos_;
            playerRot_ = T_DataManager.Instance.playerdata_.playerRot_;

            GameManager.Instance.player.transform.position = playerPos_;
            GameManager.Instance.player.transform.rotation = playerRot_;

            //time
            minute_ = T_DataManager.Instance.timedata_.minute;
            hour_ = T_DataManager.Instance.timedata_.hour;
            day_ = T_DataManager.Instance.timedata_.day;

            TimeController.Instance.minute = minute_;
            TimeController.Instance.hour = hour_;
            TimeController.Instance.day = day_;

            //graphics
            isCloudOn_ = T_DataManager.Instance.en_Data_.isCloudOn;
            isStarOn_ = T_DataManager.Instance.en_Data_.isStarOn;
            isShadowOn_ = T_DataManager.Instance.en_Data_.isShadowOn;
            isWaterHigh_ = T_DataManager.Instance.en_Data_.isWaterHigh;
            isLightImprovement_ = T_DataManager.Instance.en_Data_.isLightImprovement;
            isFullScreenOn_ = T_DataManager.Instance.en_Data_.isFullScreenOn;
            width_ = T_DataManager.Instance.en_Data_.width;
            height_ = T_DataManager.Instance.en_Data_.height;

            

            T_DataManager.Instance.isLoadOn = false;
        }
    }

    new void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            T_DataManager.Instance.playerdata_.playerPos_ = GameManager
                .Instance
                .player
                .transform
                .position;
            T_DataManager.Instance.playerdata_.playerRot_ = GameManager
                .Instance
                .player
                .transform
                .rotation;

            T_DataManager.Instance.timedata_.minute = TimeController.Instance.minute;
            T_DataManager.Instance.timedata_.hour = TimeController.Instance.hour;
            T_DataManager.Instance.timedata_.day = TimeController.Instance.day;
            Debug.Log(
                $"{TimeController.Instance.day} . {TimeController.Instance.hour} : {TimeController.Instance.minute}"
            );
        }
    }
}
