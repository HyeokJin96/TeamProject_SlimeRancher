using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorbedState : IActionState
{
    SlimeBase slimeBase;
    public AbsorbedState(SlimeBase slimeBase)
    {
        this.slimeBase = slimeBase;
    }

    public void Enter()
    {

    }

    public void Update()
    {
        if (!slimeBase.isPickup)
        {
            slimeBase.actionStateMachine.TransitionTo(slimeBase.actionStateMachine.idleState);
        }
    }

    public void Exit()
    {

    }
}


