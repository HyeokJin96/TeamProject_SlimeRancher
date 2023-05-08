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
    public MeshRenderer water_ = default;

    public GameObject sun = default;
    public Light sun_ = default;

    public int width = 1920;
    public int height = 1080;

    public bool isFullScreenOn = true;
    public bool isCloudOn = true;
    public bool isStarOn = true;
    public bool isShadowOn = true;
    public bool isLightImprovement = true;
    public bool isWaterImprovement = true;

    public bool isHaveKey = false;
    public bool isInHouse = false;

    [SerializeField]
    public float mouseSensitivity = default; //  ���콺 ����

    public new void Awake()
    {
        /*Ignore DontDestroy*/
        water_ = water.GetComponent<MeshRenderer>();
        sun_ = sun.GetComponent<Light>();
    }

    public void FullScreenOn()
    {
        isFullScreenOn = !isFullScreenOn;
        if (isFullScreenOn == false)
        {
            Screen.SetResolution(width, height, false);
            UIManager.Instance.Img_Check_F.SetActive(false);
        }
        else
        {
            Screen.SetResolution(width, height, true);
            UIManager.Instance.Img_Check_F.SetActive(true);
        }
    }

    public void StarOn()
    {
        isStarOn = !isStarOn;
    }

    public void CloudOn()
    {
        isCloudOn = !isCloudOn;
    }

    public void ShadowOn()
    {
        isShadowOn = !isShadowOn;
    }

    public void LightQuality()
    {
        isLightImprovement = !isLightImprovement;
    }

    public void WaterOn()
    {
        isWaterImprovement = !isWaterImprovement;
    }
}
