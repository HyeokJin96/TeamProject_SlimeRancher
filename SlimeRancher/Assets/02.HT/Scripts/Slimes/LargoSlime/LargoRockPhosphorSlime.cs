using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargoRockPhosphorSlime : SlimeBase
{
    //[SimeSize] 0: normal, 1: largo 2: gordo
    //[SlimeType]  0: Default(White), 1: Pink, 2: Rock...
    GameObject rockAttachment;
    GameObject rockSpineLod0;
    GameObject rockSpineLod1;

    Material rockSpineLod0Mat;
    Material rockSpineLod1Mat;
    public override void Start()
    {
        base.Start();
        slimeSize = 1;
        slimeType1 = 2;
        slimeType2 = 4;

        defaultMaterial.color = slimeColor[4];
        defaultLod1Material.color = slimeColor[4];
        defaultLod2Material.color = slimeColor[4];
        defaultLod3Material.color = slimeColor[4];
        targetDistanceValue1 = 7;
        targetDistanceValue2 = 5;

        rockAttachment = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject;
        rockSpineLod0 = shadow.GetChild(4).gameObject;
        rockSpineLod1 = shadow.GetChild(5).gameObject;

        rockAttachment.SetActive(true);
        rockSpineLod0.SetActive(true);
        rockSpineLod1.SetActive(true);

        rockAttachment.transform.GetChild(0).GetComponent<MeshRenderer>().materials[0].color = slimeColor[4];
        rockSpineLod0.transform.GetChild(0).GetComponent<MeshRenderer>().materials[0].color = slimeColor[4];
        rockSpineLod1.transform.GetChild(0).GetComponent<MeshRenderer>().materials[0].color = slimeColor[4];

        defaultColor = slimeColor[4];
    }

    public override void Update()
    {
        base.Update();
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
}
