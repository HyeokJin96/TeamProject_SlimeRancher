using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotation : MonoBehaviour
{
    private Light thisLight = default;
    public static bool isDay = false;

    float timer = 0;
    float setTime_sec = 5f;
    int setTime_min = 0;

    private void Start()
    {
        isDay = true;
        thisLight = gameObject.GetComponent<Light>();

        transform.localEulerAngles = new Vector3(180, 0, 0);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        RotateSun();
        SunColor();

        TimeChecker();
    }

    private void RotateSun()
    {
        transform.Rotate(new Vector3(-0.25f, 0, 0) * Time.deltaTime);

        if (setTime_min == 12)
        {
            isDay = false;
        }

        if (setTime_min == 24)
        {
            isDay = true;
            setTime_min = 0;
        }
    }

    private void TimeChecker()
    {
        if (timer >= setTime_sec)
        {
            setTime_min++;
            timer = 0;
        }
    }

    private void SunColor()
    {
        if (isDay == false)
        {
            thisLight.intensity -= 0.05555f * Time.deltaTime;
        }
        else
        {
            if (thisLight.intensity < 1)
            {
                thisLight.intensity += 0.05555f * Time.deltaTime;
            }
        }

        if (thisLight.intensity > 1f)
        {
            thisLight.intensity = 1;
        }
    }
}
