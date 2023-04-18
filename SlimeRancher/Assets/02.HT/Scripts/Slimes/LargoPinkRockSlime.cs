using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargoPinkRockSlime : SlimeBase
{
    //[SimeSize] 0: normal, 1: largo 2: gordo
    //[SlimeType]  0: Default(White), 1: Pink, 2: Rock...
    public override void Start()
    {
        base.Start();
        slimeSize = 1;
        slimeType1 = 1;
        slimeType2 = 2;

        defaultMaterial.color = slimeColor[1];
        defaultLod1Material.color = slimeColor[1];
        defaultLod2Material.color = slimeColor[1];
        defaultLod3Material.color = slimeColor[1];
        targetDistanceValue1 = 7;
        targetDistanceValue2 = 5;
    }

    public override void Update()
    {
        base.Update();
    }
}
