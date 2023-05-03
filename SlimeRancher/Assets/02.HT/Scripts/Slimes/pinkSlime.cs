using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinkSlime : SlimeBase
{
    //[SimeSize] 0: normal, 1: largo 2: gordo
    //[SlimeType]  0: Default(White), 1: Pink, 2: Rock...

    public override void Start()
    {
        base.Start();
        slimeSize = 0;
        slimeType1 = 1;

        defaultMaterial.color = slimeColor[1];
        defaultLod1Material.color = slimeColor[1];
        defaultLod2Material.color = slimeColor[1];
        defaultLod3Material.color = slimeColor[1];

        //test
        slimeName = "Pink Slime";
        slimeIcon = Resources.Load<Sprite>("02.HT/Slimes/PinkSlime/iconSlimePink");
        //test

    }

    public override void Update()
    {
        base.Update();
    }
}
