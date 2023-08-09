using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargoRockRadSlime : SlimeBase
{
    //[SimeSize] 0: normal, 1: largo 2: gordo
    //[SlimeType]  0: Default(White), 1: Pink, 2: Rock...
    GameObject rockAttachment;
    GameObject rockSpineLod0;
    GameObject rockSpineLod1;

    Material rockSpineLod0Mat;
    Material rockSpineLod1Mat;
    public Material radField;
    float defaultRadFieldValue;
    float currentRadFieldValue;
    bool isMotionSetTrigger = default;
    public override void Start()
    {
        base.Start();
        slimeSize = 1;
        slimeType1 = 2;
        slimeType2 = 6;

        defaultMaterial.color = slimeColor[6];
        defaultLod1Material.color = slimeColor[6];
        defaultLod2Material.color = slimeColor[6];
        defaultLod3Material.color = slimeColor[6];

        defaultMaterial.SetColor("_EmissionColor", slimeColor[6]);
        defaultLod1Material.SetColor("_EmissionColor", slimeColor[6]);
        defaultLod2Material.SetColor("_EmissionColor", slimeColor[6]);
        defaultLod3Material.SetColor("_EmissionColor", slimeColor[6]);



        targetDistanceValue1 = 7;
        targetDistanceValue2 = 5;

        rockAttachment = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject;
        rockSpineLod0 = shadow.GetChild(4).gameObject;
        rockSpineLod1 = shadow.GetChild(5).gameObject;

        rockAttachment.SetActive(true);
        rockSpineLod0.SetActive(true);
        rockSpineLod1.SetActive(true);

        rockAttachment.transform.GetChild(0).GetComponent<MeshRenderer>().materials[0].color = slimeColor[6];
        rockSpineLod0.transform.GetChild(0).GetComponent<MeshRenderer>().materials[0].color = slimeColor[6];
        rockSpineLod1.transform.GetChild(0).GetComponent<MeshRenderer>().materials[0].color = slimeColor[6];

        //radField = shadow.GetChild(6).GetComponent<MeshRenderer>().materials[0];
        radField = transform.GetChild(3).GetComponent<MeshRenderer>().materials[0];
        defaultRadFieldValue = 0.9f;
        currentRadFieldValue = defaultRadFieldValue;

        defaultColor = slimeColor[6];
    }

    public override void Update()
    {
        base.Update();

        SetRadFieldMotion();
    }

    public override void Action()
    {
        int frequency_;
        frequency_ = Random.Range(0, 5);
        if (frequency_ >= 0 && frequency_ < 3)
        {
            currentActionState = ActionState.Jump;
        }
        else
        {
            currentActionState = ActionState.RockFire;
        }
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
