using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotation : MonoBehaviour
{
    private Light thisLight = default;
    public static bool isDay = false;

    private void Start()
    {
        thisLight = gameObject.GetComponent<Light>();

        // Set Morning
        isDay = true;
        transform.localEulerAngles = new Vector3(
            270 + (-0.25f * (TimeController.Instance.minute + (TimeController.Instance.hour * 60))),
            0,
            0
        );
    }

    private void Update()
    {
        if (Time.timeScale == 1)
        {
            RotateSun();
            SunColor();
        }
    }

    private void RotateSun()
    {
        // Sun Rotation
        transform.Rotate(new Vector3(-0.25f, 0, 0) * Time.deltaTime 
        * TimeController.Instance.nTimesFaster);
    }

    private void SunColor()
    {
        // Sun Bright
        if(TimeController.Instance.hour == 6)
        {
            isDay = true;
        }

        if(TimeController.Instance.hour == 18)
        {
            isDay = false;
        }

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
