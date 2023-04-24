using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : KSingleton<GameManager>
{
    //caching
    public GameObject player = default;
    public Vector3 playerPos = default;
    public Quaternion playerRot = default;

    public GameObject cloud = default;
    public GameObject star = default;

    public GameObject water = default;
    private MeshRenderer water_ = default;

    public GameObject sun = default;
    private Light sun_ = default;

    public int width = 1920;
    public int height = 1080;

    public bool isCloudOn = true;
    public bool isStarOn = true;
    public bool isShadowOn = true;
    public bool isWaterHigh = true;
    public bool isLightImprovement = true;
    public bool isFullScreenOn = true;

    [SerializeField]
    public float mouseSensitivity = default; //  ���콺 ����

    public new void Awake()
    {
        /*Ignore DontDestroy*/

        water_ = water.GetComponent<MeshRenderer>();
        sun_ = sun.GetComponent<Light>();
    }

    public void CloudOn()
    {
        if (isCloudOn == false)
        {
            cloud.SetActive(false);
        }
        else
        {
            cloud.SetActive(true);
        }
    }

    public void StarOn()
    {
        isStarOn = !isStarOn;

        if (isStarOn == false)
        {
            star.SetActive(false);
        }
        else
        {
            star.SetActive(true);
        }
    }

    public void WaterOn()
    {
        isWaterHigh = !isWaterHigh;

        if (isWaterHigh == false)
        {
            water.SetActive(false);
        }
        else
        {
            water.SetActive(true);
        }
    }

    public void ShadowOn()
    {
        isShadowOn = !isShadowOn;

        if (isShadowOn == false)
        {
            sun_.shadows = LightShadows.None;
        }
        else
        {
            sun_.shadows = LightShadows.Soft;
        }
    }

    public void LightQuality()
    {
        isLightImprovement = !isLightImprovement;

        if (isLightImprovement == false)
        {
            QualitySettings.shadowResolution = ShadowResolution.Medium;
        }
        else
        {
            QualitySettings.shadowResolution = ShadowResolution.VeryHigh;
        }
    }

    public void FullScreenOn()
    {
        isFullScreenOn = !isFullScreenOn;
        if (isFullScreenOn == false)
        {
            Screen.SetResolution(width, height, false);
        }
        else
        {
            Screen.SetResolution(width, height, true);
        }
    }
}
