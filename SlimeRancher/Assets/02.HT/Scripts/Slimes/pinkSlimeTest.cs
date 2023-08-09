using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinkSlimeTest : SlimeBase
{
    public override void Update()
    {
        base.Update();

        if (isGrounded)
        {
            Jump(7, 7);
        }
    }
    public override void Action()
    {
        throw new System.NotImplementedException();
    }
}
