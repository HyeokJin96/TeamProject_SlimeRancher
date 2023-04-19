using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabbySlime : SlimeBase
{
    //[SimeSize] 0: normal, 1: largo 2: gordo
    //[SlimeType]  0: Default(White), 1: Pink, 2: Rock...

    Material rockSpineLod0Mat;
    Material rockSpineLod1Mat;

    Texture2D tabbyBodyTexture;
    Texture2D tabbyEarNTailTexture1;
    Texture2D tabbyEarNTailTexture2;
    public override void Start()
    {
        base.Start();
        slimeSize = 0;
        slimeType1 = 2;

        defaultMaterial.color = slimeColor[3];
        defaultLod1Material.color = slimeColor[3];
        defaultLod2Material.color = slimeColor[3];
        defaultLod3Material.color = slimeColor[3];


        tabbyBodyTexture = Resources.Load<Texture2D>("02.HT/Slimes/TabbySlime/TabbyBodyStripe");
        tabbyEarNTailTexture1 = Resources.Load<Texture2D>("02.HT/Slimes/TabbySlime/tabbyEarNTailTexture1");
        tabbyEarNTailTexture2 = Resources.Load<Texture2D>("02.HT/Slimes/TabbySlime/tabbyEarNTailTexture2");

        defaultMaterial.SetTexture("_MainTex", tabbyBodyTexture);
        defaultLod1Material.SetTexture("_MainTex", tabbyBodyTexture);
        defaultLod2Material.SetTexture("_MainTex", tabbyBodyTexture);
        defaultLod3Material.SetTexture("_MainTex", tabbyBodyTexture);


        tabbyEarsAndTail.SetActive(true);



    }

    public override void Update()
    {
        base.Update();
    }
}
