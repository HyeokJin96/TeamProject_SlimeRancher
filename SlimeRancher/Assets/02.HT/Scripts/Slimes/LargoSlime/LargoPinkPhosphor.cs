using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargoPinkPhosphor : SlimeBase
{
    //[SimeSize] 0: normal, 1: largo 2: gordo
    //[SlimeType]  0: Default(White), 1: Pink, 2: Rock...
    public override void Start()
    {
        base.Start();
        slimeSize = 1;
        slimeType1 = 1;
        slimeType2 = 4;

        defaultMaterial.color = slimeColor[7];
        defaultLod1Material.color = slimeColor[7];
        defaultLod2Material.color = slimeColor[7];
        defaultLod3Material.color = slimeColor[7];
        defaultMaterial.SetFloat("_Mode", 3);
        defaultLod1Material.SetFloat("_Mode", 3);
        defaultLod2Material.SetFloat("_Mode", 3);
        defaultLod3Material.SetFloat("_Mode", 3);

        targetDistanceValue1 = 7;
        targetDistanceValue2 = 5;

        defaultColor = slimeColor[7];
    }

    public override void Update()
    {
        base.Update();
    }
}
