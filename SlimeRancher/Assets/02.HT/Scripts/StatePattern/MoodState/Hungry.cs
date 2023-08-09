using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hungry : IMoodState
{
    SlimeBase slimeBase;

    public Hungry(SlimeBase slimeBase)
    {
        this.slimeBase = slimeBase;
    }

    public void Enter()
    {
        slimeBase.canEat = true;

        slimeBase.jumpForce = 6;
        slimeBase.coolTime = 7;
    }

    public void Update()
    {
        if (slimeBase.hungerValue < 33)
        {
            slimeBase.moodStateMachine.TransitionTo(slimeBase.moodStateMachine.elated);
        }
        else if (slimeBase.agitatedValue > 100)
        {
            slimeBase.moodStateMachine.TransitionTo(slimeBase.moodStateMachine.agitated);
        }
    }

    public void Exit()
    {

    }
}
