using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinkSlime : SlimeBase
{

    public override void Start()
    {
        base.Start();
        slimeType = slimeTypeArray[0];
    }

    public override void Update()
    {
        base.Update();

        if (isGrounded && currentActionState == ActionState.Idle)
        {
            Jump(5, 5);
        }
    }
}
