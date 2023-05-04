using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLoadHelper : KSingleton<TestLoadHelper>
{
    //player
    public Vector3 playerPos_ = default;
    public Quaternion playerRot_ = default;

    public float currentX;
    public float currentY;

    //time
    public float minute_ = 0;
    public float hour_ = 0;
    public int day_ = 1;

    //graphics setting
    public bool isCloudOn_ = true;
    public bool isStarOn_ = true;
    public bool isShadowOn_ = true;
    public bool isWaterImprovement_ = true;
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

            currentX = T_DataManager.Instance.trot.currentX;
            currentY = T_DataManager.Instance.trot.currentY;

            PlayerController.currentX = currentX;
            PlayerController.currentY = currentY;

            //time
            minute_ = T_DataManager.Instance.timedata_.minute;
            hour_ = T_DataManager.Instance.timedata_.hour;
            day_ = T_DataManager.Instance.timedata_.day;

            TimeController.Instance.minute = minute_;
            TimeController.Instance.hour = hour_;
            TimeController.Instance.day = day_;

            T_DataManager.Instance.isLoadOn = false;
        }
        //graphics
        isFullScreenOn_ = T_DataManager.Instance.en_Data_.isFullScreenOn;
        isStarOn_ = T_DataManager.Instance.en_Data_.isStarOn;
        isCloudOn_ = T_DataManager.Instance.en_Data_.isCloudOn;
        isShadowOn_ = T_DataManager.Instance.en_Data_.isShadowOn;
        isLightImprovement_ = T_DataManager.Instance.en_Data_.isLightImprovement;
        isWaterImprovement_ = T_DataManager.Instance.en_Data_.isWaterImprovement;
        width_ = T_DataManager.Instance.en_Data_.width;
        height_ = T_DataManager.Instance.en_Data_.height;

        GameManager.Instance.isFullScreenOn = isFullScreenOn_;
        GameManager.Instance.isStarOn = isStarOn_;
        GameManager.Instance.isCloudOn = isCloudOn_;
        GameManager.Instance.isShadowOn = isShadowOn_;
        GameManager.Instance.isLightImprovement = isLightImprovement_;
        GameManager.Instance.isWaterImprovement = isWaterImprovement_;
        GameManager.Instance.width = width_;
        GameManager.Instance.height = height_;
    }

    new void Update()
    {
        // Take Current Set
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

            T_DataManager.Instance.trot.currentX = PlayerController.currentX;
            T_DataManager.Instance.trot.currentY = PlayerController.currentY;

            T_DataManager.Instance.timedata_.minute = TimeController.Instance.minute;
            T_DataManager.Instance.timedata_.hour = TimeController.Instance.hour;
            T_DataManager.Instance.timedata_.day = TimeController.Instance.day;

            T_DataManager.Instance.en_Data_.isFullScreenOn = GameManager.Instance.isFullScreenOn;
            T_DataManager.Instance.en_Data_.isStarOn = GameManager.Instance.isStarOn;
            T_DataManager.Instance.en_Data_.isCloudOn = GameManager.Instance.isCloudOn;
            T_DataManager.Instance.en_Data_.isShadowOn = GameManager.Instance.isShadowOn;
            T_DataManager.Instance.en_Data_.isLightImprovement = GameManager.Instance.isLightImprovement;
            T_DataManager.Instance.en_Data_.isWaterImprovement = GameManager.Instance.isWaterImprovement;
            T_DataManager.Instance.en_Data_.width = GameManager.Instance.width;
            T_DataManager.Instance.en_Data_.height = GameManager.Instance.height;
        }
    }
}
