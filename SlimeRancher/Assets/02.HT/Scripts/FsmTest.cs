using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FsmTest : MonoBehaviour
{
    private enum State
    {
        IdleState,
        MoveState,
        JumpState,
        AttackState
    }

    private State currentState;

    void Start()
    {
        // 초기 상태 설정
        currentState = State.IdleState;
    }

    void Update()
    {
        switch (currentState)
        {
            case State.IdleState:
                // IdleState 처리
                break;
            case State.MoveState:
                // MoveState 처리
                break;
            case State.JumpState:
                // JumpState 처리
                break;
            case State.AttackState:
                // AttackState 처리
                break;
        }
    }

    private void TransitionToState(State nextState)
    {
        currentState = nextState;
    }
}

