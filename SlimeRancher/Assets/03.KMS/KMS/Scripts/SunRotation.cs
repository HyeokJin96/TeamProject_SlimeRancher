using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotation : MonoBehaviour
{
    private Light thisLight = default;

    public static bool isDay = false;

    public bool isMorning = false;
    public bool isAfternoon = false;
    public bool isEvening = false;
    public bool isNight = false;

    private void Start()
    {
        isDay = true;
        thisLight = gameObject.GetComponent<Light>();

        //Daybreak Start
        transform.localEulerAngles = new Vector3(90, 0, 0);
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

        if (0 < transform.eulerAngles.x && transform.eulerAngles.x <= 90)
        {
            if (isDay == true)
            {
                isAfternoon = true;
                isMorning = false;
            }
            else
            {
                isNight = true;
                isEvening = false;
            }
        }

        if (90 < transform.eulerAngles.x && transform.eulerAngles.x <= 180)
        {
            if (isDay == true)
            {
                isMorning = true;
                isNight = false;
            }
            else
            {
                isEvening = true;
                isAfternoon = false;
            }
        }

        if (transform.eulerAngles.x <= 0)
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
