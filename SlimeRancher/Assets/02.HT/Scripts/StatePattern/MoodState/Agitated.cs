using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agitated : IMoodState
{
    SlimeBase slimeBase;
    public Agitated(SlimeBase slimeBase)
    {
        this.slimeBase = slimeBase;
    }

    public void Enter()
    {
        slimeBase.canEat = true;
        
        slimeBase.jumpForce = 7;
        slimeBase.coolTime = 5;
    }

    public void Update()
    {
        if (slimeBase.hungerValue < 33)
        {
            slimeBase.moodStateMachine.TransitionTo(slimeBase.moodStateMachine.elated);
        }
    }

    public void Exit()
    {

    }
}
