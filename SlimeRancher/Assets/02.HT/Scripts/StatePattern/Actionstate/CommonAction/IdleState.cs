using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IActionState
{
    SlimeBase slimeBase;

    int numberForAction;
    
    public IdleState(SlimeBase slimeBase)
    {
        this.slimeBase = slimeBase;
    }

    public void Enter()
    {
        SetNumberForAction();

        if (!slimeBase.canAct && slimeBase.isCoolCheckEnd)
        {
            slimeBase.StartCoroutine(slimeBase.actionStateMachine.ActionCoolTime(slimeBase.coolTime, slimeBase));
        }
    }

    public void Update()
    {

        if (!slimeBase.isGround)
        {

        }
        else
        {
            if (!slimeBase.canAct)
            {
                slimeBase.actionStateMachine.TransitionTo(slimeBase.actionStateMachine.moveState);
            }
            else
            {
                SetNextAction(slimeBase.action1, slimeBase.action2, numberForAction, slimeBase);
            }
        }
    }

    public void Exit()
    {

    }



    public void SetNumberForAction()
    {

        numberForAction = Random.Range(0, 5);
    }

    public void SetNextAction(string action1, string action2, int numberForAction, SlimeBase slimeBase)
    {
        if (action1 == string.Empty && action2 == string.Empty)
        {
            slimeBase.actionStateMachine.TransitionTo(slimeBase.actionStateMachine.jumpState);
        }
        else if (action1 != string.Empty && action2 == string.Empty)
        {
            if (numberForAction < 3)
            {
                slimeBase.actionStateMachine.TransitionTo(slimeBase.actionStateMachine.jumpState);
            }
            else
            {
                slimeBase.actionStateMachine.TransitionTo(slimeBase.actionTable[action1]);
            }
        }
        else if (action1 != string.Empty && action2 != string.Empty)
        {
            switch (numberForAction)
            {
                case 0:
                    slimeBase.actionStateMachine.TransitionTo(slimeBase.actionStateMachine.jumpState);
                    break;
                case 1:
                case 2:
                    slimeBase.actionStateMachine.TransitionTo(slimeBase.actionTable[action1]);
                    break;
                case 3:
                case 4:
                    slimeBase.actionStateMachine.TransitionTo(slimeBase.actionTable[action2]);
                    break;
                default:
                    break;

            }
        }
    }
}

