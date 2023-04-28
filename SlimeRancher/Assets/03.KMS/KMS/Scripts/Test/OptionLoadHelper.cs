using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionLoadHelper : MonoBehaviour
{
    //graphics setting
    public bool isCloudOn_ = true;
    public bool isStarOn_ = true;
    public bool isShadowOn_ = true;
    public bool isWaterImprovement_ = true;
    public bool isLightImprovement_ = true;
    public bool isFullScreenOn_ = true;
    public int width_ = 1920;
    public int height_ = 1080;

    private void Awake() 
    {
        T_DataManager.Instance.LoadData_OG();
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
}
