using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockWindUpState : IActionState
{
    SlimeBase slimeBase;
    public RockWindUpState(SlimeBase slimeBase)
    {
        this.slimeBase = slimeBase;
    }

    public void Enter()
    {
        slimeBase.anim.SetBool("isWindup", true);
    }

    public void Update()
    {
        if (slimeBase.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
        {
            slimeBase.actionStateMachine.TransitionTo(slimeBase.actionStateMachine.rockFireState);
        }
    }

    public void Exit()
    {
        slimeBase.anim.SetBool("isWindup", false);
    }
}
