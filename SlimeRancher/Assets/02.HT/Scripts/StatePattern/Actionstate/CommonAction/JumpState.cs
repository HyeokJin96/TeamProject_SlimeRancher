using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : IActionState
{
    SlimeBase slimeBase;
    public JumpState(SlimeBase slimeBase)
    {
        this.slimeBase = slimeBase;
    }

    public void Enter()
    {
        slimeBase.canAct = false;
        slimeBase.isGround = false;

        slimeBase.rigid.AddForce(Vector3.up * slimeBase.jumpForce, ForceMode.Impulse);

    }
    void IActionState.Update()
    {
        if (slimeBase.isGround)
        {
            slimeBase.actionStateMachine.TransitionTo(slimeBase.actionStateMachine.idleState);
        }
    }

    public void Exit()
    {

    }
}
