using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class En_Controller : MonoBehaviour
{
    private void Update()
    {
        EnvironmentSetting();
    }

    public void EnvironmentSetting()
    {
        if (GameManager.Instance.isStarOn == false)
        {
            GameManager.Instance.star.SetActive(false);
            UIManager.Instance.Img_Check_ST.SetActive(false);
        }
        else
        {
            GameManager.Instance.star.SetActive(true);
            UIManager.Instance.Img_Check_ST.SetActive(true);
        }

        if (GameManager.Instance.isCloudOn == false)
        {
            GameManager.Instance.cloud.SetActive(false);
            UIManager.Instance.Img_Check_C.SetActive(false);
        }
        else
        {
            GameManager.Instance.cloud.SetActive(true);
            UIManager.Instance.Img_Check_C.SetActive(true);
        }

        if (GameManager.Instance.isShadowOn == false)
        {
            GameManager.Instance.sun_.shadows = LightShadows.None;
            UIManager.Instance.Img_Check_SH.SetActive(false);
        }
        else
        {
            GameManager.Instance.sun_.shadows = LightShadows.Soft;
            UIManager.Instance.Img_Check_SH.SetActive(true);
        }

        if (GameManager.Instance.isLightImprovement == false)
        {
            QualitySettings.shadowResolution = ShadowResolution.Medium;
            UIManager.Instance.Img_Check_L.SetActive(false);
        }
        else
        {
            QualitySettings.shadowResolution = ShadowResolution.VeryHigh;
            UIManager.Instance.Img_Check_L.SetActive(true);
        }

        if (GameManager.Instance.isWaterImprovement == false)
        {
            GameManager.Instance.water_.enabled = false;
            UIManager.Instance.Img_Check_W.SetActive(false);
        }
        else
        {
            GameManager.Instance.water_.enabled = true;
            UIManager.Instance.Img_Check_W.SetActive(true);
        }
    }
}
