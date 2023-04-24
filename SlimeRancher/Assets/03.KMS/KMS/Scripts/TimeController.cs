using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : KSingleton<TimeController>
{
    public float minute = 0;
    public float minute_ = 0;
    public float hour = 0;
    public float hour_ = 0;
    public int day = 1;

    private new void Awake()
    {
        hour = 6;
    }

    private new void Update()
    {
        Timer();
    }

    private void Timer()
    {
        minute += Time.deltaTime * 12;

        minute_ = Mathf.FloorToInt(minute % 60);
        hour_ = Mathf.FloorToInt(hour % 60);

        if (minute >= 60)
        {
            hour += 1;
            minute = 0;
        }

        if (hour >= 24)
        {
            hour = 0;
            day++;
        }

        string minute_S = minute_.ToString("00");
        string hour_S = hour.ToString("00");

        UIManager.Instance.inGameTime_Text_.text = "  " + hour_S + " : " + minute_S;
        UIManager.Instance.inGameDay_Text_.text = "  Day : " + day;
    }
}
