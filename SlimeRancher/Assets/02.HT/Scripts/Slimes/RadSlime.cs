using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadSlime : SlimeBase
{
    //[SimeSize] 0: normal, 1: largo 2: gordo
    //[SlimeType]  0: Default(White), 1: Pink, 2: Rock...
    public Material radField;
    float defaultRadFieldValue;
    float currentRadFieldValue;
    bool isMotionSetTrigger = default;
    public override void Start()
    {
        base.Start();
        slimeSize = 0;
        slimeType1 = 6;

        defaultMaterial.color = slimeColor[6];
        defaultLod1Material.color = slimeColor[6];
        defaultLod2Material.color = slimeColor[6];
        defaultLod3Material.color = slimeColor[6];

        radField = shadow.GetChild(4).GetComponent<MeshRenderer>().materials[0];
        defaultRadFieldValue = 0.9f;
        currentRadFieldValue = defaultRadFieldValue;

        slimeName = slimeNameList[slimeType1];
        slimeIcon = slimeIconList[slimeType1];
    }

    public override void Update()
    {
        base.Update();

        SetRadFieldMotion();
    }

    public override void Action()
    {
        currentActionState = ActionState.Jump;
    }

    void SetRadFieldMotion()
    {
        if (currentRadFieldValue > 1.2f)
        {
            isMotionSetTrigger = true;
        }
        else { }

        if (currentRadFieldValue < 0.8f)
        {
            isMotionSetTrigger = false;
        }
        else { }

        if (!isMotionSetTrigger)
        {
            currentRadFieldValue += Time.deltaTime * 0.5f;
        }
        else
        {
            currentRadFieldValue -= Time.deltaTime * 0.5f;
        }

        radField.SetFloat("_FresnelWidth", currentRadFieldValue);
    }
}
