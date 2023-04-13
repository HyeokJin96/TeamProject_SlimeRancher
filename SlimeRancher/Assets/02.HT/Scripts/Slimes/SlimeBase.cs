using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBase : MonoBehaviour
{
    protected Rigidbody rigid;

    protected bool isGrounded;
    protected bool isJumpDelay;

    public float hungerValue;   // after test, delete public 
    public float agitatedValue; // after test, delete public
    float minHunger = 0;
    float maxHunger = 100;

    SphereCollider seekRange;

    public GameObject targetToEat = null;
    Vector3 targetPosition;
    float targetDistance;

    public enum MoodState   // after test, delete public
    {
        Elated,
        Happy,
        Hungry,
        Agitated
    }
    public MoodState currentMoodState;  // after test, delete public

    public enum ActionState
    {
        Idle,
        Eat
    }

    public ActionState currentActionState;

    protected void Start()
    {
        rigid = GetComponent<Rigidbody>();

        currentMoodState = MoodState.Elated;
        currentActionState = ActionState.Idle;

        seekRange = transform.GetChild(1).GetComponent<SphereCollider>();

        StartCoroutine(IncreaseHunger(1)); // test value 1: after test, change to 60
    }

    public virtual void Update()
    {
        SetHungerValue();
        SetMoodState();
        Move();
    }

    void SetHungerValue()
    {
        if (hungerValue > maxHunger)
        {
            hungerValue = maxHunger;
        }
        else { }
    }

    protected void Jump(int jumpForce_, int delayTime_)
    {
        if (!isJumpDelay)
        {
            isGrounded = false;
            isJumpDelay = true;
            rigid.AddForce(Vector3.up * jumpForce_, ForceMode.Impulse);
            StartCoroutine(JumpDelay(delayTime_));
        }
    }
    protected void FindFood()
    {

    }

    protected void Move()
    {
        if (currentMoodState == MoodState.Elated)
        {
            //랜덤 움직임 부여 예정
        }
        else
        {
            if (targetToEat == null)
            {
                //랜덤 움직임 부여 예정
            }
            else
            {
                targetPosition = new Vector3(targetToEat.transform.position.x, transform.position.y, targetToEat.transform.position.z);
                targetDistance = Vector3.Distance(transform.position, targetPosition);

                Debug.Log(targetDistance);

                if (targetDistance > 1.5)
                {
                    currentActionState = ActionState.Idle;
                    CancelInvoke("Eat");
                    transform.LookAt(targetPosition);
                    transform.position += transform.forward * 3 * Time.deltaTime;
                }
                else if (targetDistance <= 1.5 && targetDistance > 1f)
                {
                    transform.LookAt(targetPosition);
                    transform.position += transform.forward * 3 * Time.deltaTime;
                }
                else
                {

                    //play animation bite
                    currentActionState = ActionState.Eat;
                    Invoke("Eat", 3);
                }
            }
        }
    }

    void Eat()
    {
        Debug.Log("Eat");
        hungerValue = 0;
        agitatedValue = 0;
        targetToEat.SetActive(false);
        currentActionState = ActionState.Idle;
        if (targetToEat.tag == "Plort")
        {
            Debug.Log("변신");
        }
        else if (targetToEat.tag == "Food")
        {
            Debug.Log("플로트 생산");
        }
    }

    IEnumerator JumpDelay(int delayTime_)
    {
        yield return new WaitForSeconds(delayTime_);
        isJumpDelay = false;
    }

    IEnumerator IncreaseHunger(int time_)
    {
        while (currentMoodState != MoodState.Agitated)
        {
            yield return new WaitForSeconds(time_);
            if (hungerValue != maxHunger)
            {
                hungerValue += 5.56f;
            }
            else
            {
                agitatedValue += 5.56f;
            }
        }
    }

    void SetMoodState()
    {
        if (hungerValue >= minHunger && hungerValue < 33)
        {
            currentMoodState = MoodState.Elated;
        }
        else if (hungerValue >= 33 && hungerValue < 100)
        {
            currentMoodState = MoodState.Happy;
        }
        else if (hungerValue == maxHunger)
        {
            currentMoodState = MoodState.Hungry;
        }
        else
        {

        }

        if (agitatedValue >= 100)
        {
            currentMoodState = MoodState.Agitated;
        }
        else
        {

        }
    }

    protected void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Terrain")
        {
            isGrounded = true;
        }
    }

    protected void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Terrain")
        {
            isGrounded = true;
        }
    }
}
