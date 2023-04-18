using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotation : MonoBehaviour
{
    private Light thisLight = default;
    public static bool isDay = false;

    private void Start()
    {
        isDay = true;
        thisLight = gameObject.GetComponent<Light>();

        //Daybreak Start
        transform.localEulerAngles = new Vector3(180, 0, 0);
    }

    private void Update()
    {
        RotateSun();
        // DayAndNight();
        Debug.Log(isDay);
    }

    private void RotateSun()
    {
        transform.Rotate(new Vector3(-0.25f, 0, 0) * Time.deltaTime);

        if (transform.rotation.x <= 0)
        {
            isDay = !isDay;
            transform.localEulerAngles = new Vector3(180, 0, 0);
        }
    }

    // private void DayAndNight()
    // {
    //     if (isDay == true)
    //     {
    //         thisLight.intensity = 1;
    //         RenderSettings.skybox = day;
    //     }
    //     else
    //     {
    //         thisLight.intensity = 0;
    //         RenderSettings.skybox = night;
    //     }
    // }
}
