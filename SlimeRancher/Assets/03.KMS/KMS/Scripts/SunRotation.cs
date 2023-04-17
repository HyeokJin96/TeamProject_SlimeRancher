using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotation : MonoBehaviour
{
    public bool isDay = default;
    private float timer = 0;
    private float setTime = 720;

    private void Start()
    {
        isDay = true;
    }
    //fix need
    private void Update()
    {
        RotateSun();
        timer += 1/*Time.deltaTime*/;
    }

    private void RotateSun()
    {
        if (timer == setTime && isDay == true) // change night
        {
            isDay = false;
            timer = 0;
        }

        if (timer == setTime && isDay == false) // change day
        {
            isDay = true;
            timer = 0;
        }

        if (isDay == true)
        {
            transform.Rotate(
                new Vector3(-0.25f, 0, 0)
            /**Time.deltaTime*/);
        }
        else
        {
            transform.Rotate(
                new Vector3(0.25f, 0, 0)
            /**Time.deltaTime*/);
        }
    }
}
