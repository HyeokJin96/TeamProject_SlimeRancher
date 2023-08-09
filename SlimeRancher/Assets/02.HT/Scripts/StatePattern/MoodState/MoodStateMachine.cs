using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoodStateMachine
{
    public IMoodState currentState;

    // reference to the state objects
    public Elated elated;
    public Happy happy;
    public Hungry hungry;
    public Agitated agitated;

    public MoodStateMachine(SlimeBase slimeBase)
    {
        this.elated = new Elated(slimeBase);
        this.happy = new Happy(slimeBase);
        this.hungry = new Hungry(slimeBase);
        this.agitated = new Agitated(slimeBase);
    }

    public void InitState(IMoodState moodState)
    {
        currentState = moodState;
        moodState.Enter();
    }

    public void TransitionTo(IMoodState nextState)
    {
        currentState.Exit();
        currentState = nextState;
        nextState.Enter();
    }

    public void Update()
    {
        if (currentState != null)
        {
            currentState.Update();
        }
    }


}
