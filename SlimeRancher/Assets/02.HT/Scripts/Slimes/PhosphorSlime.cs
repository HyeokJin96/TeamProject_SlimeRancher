using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhosphorSlime : SlimeBase
{
    //[SimeSize] 0: normal, 1: largo 2: gordo
    //[SlimeType]  0: Default(White), 1: Pink, 2: Rock...

    public override void Start()
    {
        base.Start();
        slimeSize = 0;
        slimeType1 = 4;

        defaultMaterial.color = slimeColor[4];
        defaultLod1Material.color = slimeColor[4];
        defaultLod2Material.color = slimeColor[4];
        defaultLod3Material.color = slimeColor[4];
        defaultMaterial.SetFloat("_Mode", 3);
        defaultLod1Material.SetFloat("_Mode", 3);
        defaultLod2Material.SetFloat("_Mode", 3);
        defaultLod3Material.SetFloat("_Mode", 3);
    }

    public override void Update()
    {
        base.Update();
    }
}
