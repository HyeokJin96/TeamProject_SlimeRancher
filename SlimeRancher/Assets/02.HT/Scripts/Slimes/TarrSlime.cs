using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarrSlime : SlimeBase
{
    // Start is called before the first frame update
    public override void Start()
    {
        //base.Start();
        rigid = GetComponent<Rigidbody>();

        currentMoodState = MoodState.Elated;
        currentActionState = ActionState.Idle;
        isTarrSlime = true;
        targetDistanceValue1 = 7;
        targetDistanceValue2 = 5;
        StartCoroutine(IncreaseHunger(1, 10)); // test value 1: after test, change to 60

        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (currentMoodState == MoodState.Agitated)
        {
            StartCoroutine(DestroyTarr());
        }
        else
        {
            StopCoroutine(DestroyTarr());
        }
    }

    // Eat(): legacy
    // public override IEnumerator Eat()
    // {
    //     currentActionState = ActionState.Wait;
    //     yield return new WaitForSeconds(3f);
    //     //working-
    //     if (targetToEat != null)
    //     {
    //         if (targetToEat.tag == "Player")
    //         {
    //             /*Do Nothing*/
    //             //player Hp 감소 추가 예정
    //             Debug.Log("player attack");
    //         }
    //         else
    //         {
    //             //다른 슬라임을 먹었을때
    //             targetToEat.transform.root.gameObject.SetActive(false);   //먹은 슬라임 false
    //             hungerValue = 0;
    //             agitatedValue = 0;
    //             targetToEat = null;
    //             Instantiate(tarrSlime, transform.position, transform.rotation); //타르 슬라임 추가 생성//차후 오브젝트풀에서 pop
    //         }
    //     }
    //     else
    //     {
    //         /*Do Nothing*/
    //     }
    //     yield return new WaitForSeconds(1f);
    //     currentActionState = ActionState.Idle;
    // }

    protected override void Eat()
    {
        if (targetToEat != null)
        {
            if (targetToEat.tag == "Player")
            {
                /*Do Nothing*/
                //player Hp 감소 추가 예정
                Debug.Log("player attack");
            }
            else
            {
                //다른 슬라임을 먹었을때
                Debug.Log("eat slime");
                //targetToEat.transform.root.transform.gameObject.SetActive(false);   //먹은 슬라임 false
                targetToEat.GetComponent<VacSlimeTest>().rootSlime.SetActive(false);
                hungerValue = 0;
                agitatedValue = 0;
                targetToEat = null;
                Instantiate(tarrSlime, transform.position, transform.rotation); //타르 슬라임 추가 생성//차후 오브젝트풀에서 pop
            }
        }
        else
        {
            /*Do Nothing*/
        }
        currentActionState = ActionState.Idle;
        anim.SetBool("isBite", false);
    }
}

