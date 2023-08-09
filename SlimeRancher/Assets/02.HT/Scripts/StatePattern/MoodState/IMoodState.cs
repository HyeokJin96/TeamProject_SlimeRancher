using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoodState
{
    void Enter();

    void Update();

    void Exit();
}
