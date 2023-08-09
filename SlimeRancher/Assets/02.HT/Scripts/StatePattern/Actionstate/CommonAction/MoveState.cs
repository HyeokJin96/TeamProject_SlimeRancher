using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : IActionState
{
    SlimeBase slimeBase;

    #region SetDestination
    float angle;
    float radiusX;
    float radiusZ;
    float posX;
    float posZ;
    Vector3 destination;
    Vector3 foodPosition;
    #endregion

    float time;


    public MoveState(SlimeBase slimeBase)
    {
        this.slimeBase = slimeBase;
    }

    public void Enter()
    {
        SetDestination();
    }

    public void Update()
    {
        Move();
        SetNextState();
    }

    public void Exit()
    {
        destination = default;
        foodPosition = default;
        time = 0;
    }

    void SetDestination()
    {
        if (slimeBase.targetToEat != null)
        {
            foodPosition = new Vector3(slimeBase.targetToEat.transform.position.x, slimeBase.transform.position.y, slimeBase.targetToEat.transform.position.z);
        }

        if (slimeBase.canEat && slimeBase.targetToEat != null)
        {
            destination = foodPosition;
        }
        else
        {
            angle = Random.Range(0f, 360f);
            radiusX = Random.Range(5, 10);
            radiusZ = Random.Range(5, 10);

            posX = slimeBase.transform.position.x + radiusX * Mathf.Cos(angle * Mathf.Deg2Rad);
            posZ = slimeBase.transform.position.z + radiusZ * Mathf.Sin(angle * Mathf.Deg2Rad);
            destination = new Vector3(posX, slimeBase.transform.position.y, posZ);
        }
    }

    void SetNextState()
    {
        time += Time.deltaTime;

        if (slimeBase.isReadyToEat)
        {
            slimeBase.actionStateMachine.TransitionTo(slimeBase.actionStateMachine.eatState);
        }

        if (time > 3 || Vector3.Distance(slimeBase.transform.position, destination) < 0.3f)
        {
            slimeBase.actionStateMachine.TransitionTo(slimeBase.actionStateMachine.idleState);
        }
    }

    void Move()
    {
        slimeBase.transform.LookAt(destination);
        slimeBase.transform.position += slimeBase.transform.forward * 3 * Time.deltaTime;
    }
}


