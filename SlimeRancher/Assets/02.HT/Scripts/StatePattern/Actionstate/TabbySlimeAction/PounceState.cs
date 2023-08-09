using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PounceState : IActionState
{
    SlimeBase slimeBase;
    Vector3 pos1;
    Vector3 pos2;
    float t;

    public PounceState(SlimeBase slimeBase)
    {
        this.slimeBase = slimeBase;
    }

    public void Enter()
    {
        slimeBase.anim.SetBool("isPounce", true);

        pos1 = slimeBase.transform.position;
        pos2 = slimeBase.pounceTarget.position;
        t = 0;
    }

    public void Update()
    {
        if (slimeBase.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.85f)
        {
            if (t < 1)
            {
                t += Time.deltaTime * 0.5f;
            }
            else if (t >= 1)
            {
                slimeBase.actionStateMachine.TransitionTo(slimeBase.actionStateMachine.idleState);
            }

            slimeBase.transform.position = Vector3.Slerp(pos1, pos2, t);
        }
    }

    public void Exit()
    {
        slimeBase.anim.SetBool("isPounce", false);

        pos1 = default;
        pos2 = default;
        t = 0;
    }
}


