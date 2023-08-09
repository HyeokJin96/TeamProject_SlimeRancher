using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockRecoverState : IActionState
{
    SlimeBase slimeBase;
    public RockRecoverState(SlimeBase slimeBase)
    {
        this.slimeBase = slimeBase;
    }

    public void Enter()
    {
        slimeBase.anim.SetBool("isRockRecover", true);
    }

    public void Update()
    {
        if (slimeBase.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.3f)
        {
            slimeBase.rigid.velocity = Vector3.zero;
            slimeBase.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (slimeBase.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
        {
            slimeBase.actionStateMachine.TransitionTo(slimeBase.actionStateMachine.idleState);
        }
    }

    public void Exit()
    {
        slimeBase.anim.SetBool("isRockRecover", false);
    }
}
