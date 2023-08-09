using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionStateMachine
{
    public IActionState currentState;

    // reference to the state objects
    public IdleState idleState;
    public MoveState moveState;
    public JumpState jumpState;
    public EatState eatState;
    public RockFireState rockFireState;
    public RockWindUpState rockWindUpState;
    public RockRecoverState rockRecoverState;
    public PounceState pounceState;
    public BoomState boomState;
    public StunState stunState;
    public AbsorbedState absorbedState;

    public ActionStateMachine(SlimeBase slimeBase)
    {
        this.idleState = new IdleState(slimeBase);
        this.moveState = new MoveState(slimeBase);
        this.jumpState = new JumpState(slimeBase);
        this.eatState = new EatState(slimeBase);
        this.rockWindUpState = new RockWindUpState(slimeBase);
        this.rockFireState = new RockFireState(slimeBase);
        this.rockRecoverState = new RockRecoverState(slimeBase);
        this.pounceState = new PounceState(slimeBase);
        this.boomState = new BoomState(slimeBase);
        this.stunState = new StunState(slimeBase);
        this.absorbedState = new AbsorbedState(slimeBase);

        slimeBase.actionTable.Add("RockWindUp", rockWindUpState);
        slimeBase.actionTable.Add("Pounce", pounceState);
        slimeBase.actionTable.Add("Boom", boomState);
    }

    public void InitState(IActionState actionState)
    {
        currentState = actionState;
        currentState.Enter();
    }

    public void TransitionTo(IActionState nextState)
    {
        currentState.Exit();
        currentState = nextState;
        nextState.Enter();
    }

    public void Act()
    {
        if (currentState != null)
        {
            currentState.Update();
        }
    }

    //coroutine in slimebase.start()
    public IEnumerator ActionCoolTime(int coolTime, SlimeBase slimeBase)
    {
        slimeBase.isCoolCheckEnd = false;
        yield return new WaitForSeconds(coolTime);
        slimeBase.canAct = true;
        slimeBase.isCoolCheckEnd = true;
    }
}
