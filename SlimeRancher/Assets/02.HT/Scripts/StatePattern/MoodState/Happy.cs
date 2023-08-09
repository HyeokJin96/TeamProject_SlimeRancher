using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Happy : IMoodState
{
    SlimeBase slimeBase;

    public Happy(SlimeBase slimeBase)
    {
        this.slimeBase = slimeBase;
    }


    public void Enter()
    {
        slimeBase.canEat = true;
        
        slimeBase.jumpForce = 5;
        slimeBase.coolTime = 10;
    }

    public void Update()
    {
        if (slimeBase.hungerValue < 33)
        {
            slimeBase.moodStateMachine.TransitionTo(slimeBase.moodStateMachine.elated);
        }
        else if (slimeBase.hungerValue == slimeBase.maxHunger)
        {
            slimeBase.moodStateMachine.TransitionTo(slimeBase.moodStateMachine.hungry);
        }
    }

    public void Exit()
    {

    }
}
