using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCoreTest2 : MonoBehaviour
{
    Light lightComponent;
    bool checkpoint1;
    bool checkpoint2;
    float lightRangeValue;

    public float maxLightRange;
    // Start is called before the first frame update
    void Start()
    {
        lightComponent = GetComponent<Light>();
        lightRangeValue = lightComponent.range;
        checkpoint1 = true;
    }

    // Update is called once per frame
    void Update()
    {


        if (lightRangeValue <= 0)
        {
            checkpoint1 = true;
            checkpoint2 = false;
        }

        if (lightRangeValue >= maxLightRange)
        {
            checkpoint1 = false;
            checkpoint2 = true;
        }

        lightComponent.range = lightRangeValue;

        if (lightRangeValue < 1)
        {
            lightComponent.range = 0;
        }

        StartCoroutine(SetLightRange());
    }

    IEnumerator SetLightRange()
    {
        yield return new WaitForSeconds(1f);

        /* if (lightRangeValue <= 0)
        {
            yield return new WaitForSeconds(1);
        } */

        if (checkpoint1)
        {
            lightRangeValue += 0.01f;
        }

        if (checkpoint2)
        {
            lightRangeValue -= 0.01f;
        }
    }
}
