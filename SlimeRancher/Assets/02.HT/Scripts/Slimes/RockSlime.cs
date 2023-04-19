using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSlime : SlimeBase
{
    //[SimeSize] 0: normal, 1: largo 2: gordo
    //[SlimeType]  0: Default(White), 1: Pink, 2: Rock...

    Material rockSpineLod0Mat;
    Material rockSpineLod1Mat;
    public override void Start()
    {
        base.Start();
        slimeSize = 0;
        slimeType1 = 2;

        defaultMaterial.color = slimeColor[2];
        defaultLod1Material.color = slimeColor[2];
        defaultLod2Material.color = slimeColor[2];
        defaultLod3Material.color = slimeColor[2];

        rockAttachment.SetActive(true);
        rockSpineLod0.SetActive(true);
        rockSpineLod1.SetActive(true);

        rockAttachment.transform.GetChild(0).GetComponent<MeshRenderer>().materials[0].color = new Color32(125, 180, 245, 255);
        rockSpineLod0.transform.GetChild(0).GetComponent<MeshRenderer>().materials[0].color = new Color32(125, 180, 245, 255);
        rockSpineLod1.transform.GetChild(0).GetComponent<MeshRenderer>().materials[0].color = new Color32(125, 180, 245, 255);
    }

    public override void Update()
    {
        base.Update();
    }
}
