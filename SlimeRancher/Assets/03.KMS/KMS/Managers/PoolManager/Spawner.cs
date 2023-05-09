using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject pinkSlime_S = default;
    public GameObject rockSlime_S = default;
    public GameObject tabbySlime_S = default;
    public GameObject radSlime_S = default;
    public GameObject boomSlime_S = default;
    public GameObject phSlime_S = default;

    private void Update()
    {
        if (
            (TimeController.Instance.hour == 6 && TimeController.Instance.minute == 0)
            || (TimeController.Instance.hour == 12 && TimeController.Instance.minute == 0)
            || (TimeController.Instance.hour == 18 && TimeController.Instance.minute == 0)
        )
        {
            pinkSlime_S.SetActive(true);
            rockSlime_S.SetActive(true);
            tabbySlime_S.SetActive(true);
            radSlime_S.SetActive(true);
            boomSlime_S.SetActive(true);
            phSlime_S.SetActive(true);
        }
    }
}
