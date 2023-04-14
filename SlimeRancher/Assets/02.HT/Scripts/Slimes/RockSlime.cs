using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSlime : SlimeBase
{
    //[SimeSize] 0: normal, 1: largo 2: gordo
    //[SlimeType]  0: Default(White), 1: Pink, 2: Rock...
    public override void Start()
    {
        base.Start();
        slimeSize = 0;
        slimeType1 = 2;

        defaultMaterial.color = slimeColor[2];
        defaultLod1Material.color = slimeColor[2];
        defaultLod2Material.color = slimeColor[2];
        defaultLod3Material.color = slimeColor[2];
    }

    public override void Update()
    {
        base.Update();
    }
}
