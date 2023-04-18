using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ChangeSkyBox : MonoBehaviour
{
    public Material Skybox_Day;
    public Material Skybox_night;
    public float duration = 360.0f;

    private Material currentSkybox;
    private float blendFactor = 0.0f;

    void Start()
    {
        currentSkybox = new Material(Skybox_Day);
        RenderSettings.skybox = currentSkybox;
    }

    void Update()
    {
        // if(SunRotation.isDay == true)
        // {
        //     ChangeToNight();
        //     Debug.Log(blendFactor);
        // }
        
        // if(SunRotation.isDay == false)
        // {
        //     ChangeToDay();
        //     Debug.Log("낮되냐");
        // }
    }

    private void ChangeToNight()
    {
        blendFactor += Time.deltaTime / duration;
        blendFactor = Mathf.Clamp01(blendFactor);

        currentSkybox.Lerp(Skybox_Day, Skybox_night, blendFactor);
        RenderSettings.skybox = currentSkybox;
    }

    private void ChangeToDay()
    {
        blendFactor += Time.deltaTime / duration;
        blendFactor = Mathf.Clamp01(blendFactor);

        currentSkybox.Lerp(Skybox_night, Skybox_Day, blendFactor);
        RenderSettings.skybox = currentSkybox;
    }
}
