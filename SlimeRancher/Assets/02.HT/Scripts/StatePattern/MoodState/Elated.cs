using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elated : IMoodState
{
    SlimeBase slimeBase;

    public Elated(SlimeBase slimeBase)
    {
        this.slimeBase = slimeBase;
    }

    public void Enter()
    {
        slimeBase.canEat = false;
        
        slimeBase.jumpForce = 5;
        slimeBase.coolTime = 10;
    }

    public void Update()
    {
        if (slimeBase.hungerValue >= 33)
        {
            slimeBase.moodStateMachine.TransitionTo(slimeBase.moodStateMachine.happy);
        }
    }

    public void Exit()
    {
        // do something when exit the state
    }
}
