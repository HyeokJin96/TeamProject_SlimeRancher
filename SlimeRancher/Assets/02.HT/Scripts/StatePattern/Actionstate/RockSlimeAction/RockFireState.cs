using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockFireState : IActionState
{
    SlimeBase slimeBase;
    public RockFireState(SlimeBase slimeBase)
    {
        this.slimeBase = slimeBase;
    }

    public void Enter()
    {
        slimeBase.anim.SetBool("isRockFire", true);
        slimeBase.rigid.AddForce(slimeBase.transform.forward * 20, ForceMode.Impulse);
    }

    public void Update()
    {
        if (slimeBase.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
        {
            slimeBase.actionStateMachine.TransitionTo(slimeBase.actionStateMachine.rockRecoverState);
        }
    }

    public void Exit()
    {
        slimeBase.anim.SetBool("isRockFire", false);
    }
}
