using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findFood : MonoBehaviour
{
    SlimeBase slimeBase;
    GameObject closestObject = null;


    // Start is called before the first frame update
    void Start()
    {
        slimeBase = transform.parent.GetComponent<SlimeBase>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {

        if (!slimeBase.isTarrSlime)
        {
            if (slimeBase.currentMoodState != SlimeBase.MoodState.Elated && slimeBase.currentActionState == SlimeBase.ActionState.Idle && (slimeBase.targetToEat == null || slimeBase.targetToEat.activeSelf == false))
            {
                if (other.gameObject.CompareTag("Plort") || other.gameObject.CompareTag("Food"))
                {
                    if (other.gameObject.CompareTag("Plort"))
                    {
                        if (other.GetComponent<PlortBase>().plortType != slimeBase.slimeType1 && other.GetComponent<PlortBase>().plortType != slimeBase.slimeType2)
                        {
                            PlortCheck(other.gameObject.GetComponents<Collider>());
                        }
                    }
                    else
                    {
                        PlortCheck(other.gameObject.GetComponents<Collider>());
                    }
                }
            }
        }
        else
        {
            //temporary test
            if (slimeBase.currentMoodState != SlimeBase.MoodState.Elated && slimeBase.currentActionState == SlimeBase.ActionState.Idle && (slimeBase.targetToEat == null || slimeBase.targetToEat.activeSelf == false))
            {

                if (other.gameObject.CompareTag("Normal Slime") || other.gameObject.CompareTag("Largo Slime") || other.gameObject.CompareTag("Player"))
                {
                    PlortCheck(other.gameObject.GetComponents<Collider>());
                }
            }
            //test
        }
    }

    void PlortCheck(Collider[] collider_)
    {

        float minDistance_ = float.MaxValue;
        float distance_;

        foreach (Collider collider in collider_)
        {
            distance_ = Vector3.Distance(transform.position, collider.transform.position);
            if (distance_ < minDistance_)
            {
                minDistance_ = distance_;
                closestObject = collider.gameObject;
            }
        }

        if (closestObject != null)
        {
            slimeBase.targetToEat = closestObject;
        }
        else
        {
            // 특정 태그를 가진 오브젝트가 없는 경우
        }
    }

    public GameObject pounceTarget;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            pounceTarget = other.gameObject;
            slimeBase.pounceTarget = pounceTarget.transform;
        }
        else if (pounceTarget == null && other.tag == "Food")
        {
            pounceTarget = other.gameObject;
            slimeBase.pounceTarget = pounceTarget.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == slimeBase.targetToEat)
        {
            slimeBase.targetToEat = null;
        }
        else
        {

        }

        if (pounceTarget != null && other.gameObject == pounceTarget)
        {
            pounceTarget = null;
            slimeBase.pounceTarget = null;
            //pounceTarget.transform;
        }
        else
        {

        }
    }
}
