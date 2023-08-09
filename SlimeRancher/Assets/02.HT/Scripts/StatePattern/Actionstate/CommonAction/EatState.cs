using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatState : IActionState
{
    SlimeBase slimeBase;

    public EatState(SlimeBase slimeBase)
    {
        this.slimeBase = slimeBase;
    }

    public void Enter()
    {
        slimeBase.anim.SetBool("isBite", true);
    }
    public void Update()
    {
        if (slimeBase.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.6f)
        {

            slimeBase.actionStateMachine.TransitionTo(slimeBase.actionStateMachine.idleState);
        }
    }
    public void Exit()
    {
        slimeBase.anim.SetBool("isBite", false);

        if (slimeBase.targetToEat.tag == "Food")
        {
            slimeBase.MakePlort();
        }
        else if (slimeBase.targetToEat.tag == "Plort")
        {
            slimeBase.TransformSlime();
        }

        slimeBase.targetToEat.SetActive(false);
        slimeBase.hungerValue = 0;
        slimeBase.agitatedValue = 0;
        slimeBase.isReadyToEat = false;
        slimeBase.targetToEat = null;
    }
}
