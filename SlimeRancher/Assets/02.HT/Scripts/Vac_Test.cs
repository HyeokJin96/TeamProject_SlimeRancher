using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vac_Test : MonoBehaviour
{
    public GameObject blackhole;

    GameObject[] stars;

    float time;

    Vector3 dir;

    public bool fuckU;

    public GameObject joint1;
    public GameObject joint2;
    public GameObject joint2_OriginPos;
    Vector3 joint2DefaultPos;
    public GameObject joint3;
    public GameObject joint3_OriginPos;
    Vector3 joint3DefaultPos;
    public GameObject joint4;
    public GameObject joint4_OriginPos;
    Vector3 joint4DefaultPos;
    public GameObject joint5;
    public GameObject joint5_OriginPos;
    Vector3 joint5DefaultPos;
    public GameObject joint6;
    public GameObject joint6_OriginPos;
    Vector3 joint6DefaultPos;

    GameObject[] jointArray;

    private void Start()
    {
        blackhole.SetActive(false);

        // "Star"?? ?¡¾?? ?????? ???????????? ???? Star ?ò÷?? ??¢¥?.
        //stars = GameObject.FindGameObjectsWithTag("Star");
        stars = GameObject.FindGameObjectsWithTag("Normal Slime");

        jointArray = new GameObject[] { joint1, joint2, joint3, joint4, joint5, joint6 };

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            blackhole.SetActive(true);
            joint2DefaultPos = joint2.transform.position;
            joint3DefaultPos = joint3.transform.position;
            joint4DefaultPos = joint4.transform.position;
            joint5DefaultPos = joint5.transform.position;
            joint6DefaultPos = joint6.transform.position;
            fuckU = true;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            blackhole.SetActive(false);
            fuckU = false;
            isCheckEnd = false;
        }


        time += Time.deltaTime;

        if (fuckU)
        {
            joint2.transform.position = joint2DefaultPos;
            joint3.transform.position = joint3DefaultPos;
            joint4.transform.position = joint4DefaultPos;
            joint5.transform.position = joint5DefaultPos;
            joint6.transform.position = joint6DefaultPos;

            joint2DefaultPos = Vector3.Slerp(joint2DefaultPos, joint2_OriginPos.transform.position, 0.5f);
            joint3DefaultPos = Vector3.Slerp(joint3DefaultPos, joint3_OriginPos.transform.position, 0.4f);
            joint4DefaultPos = Vector3.Slerp(joint4DefaultPos, joint4_OriginPos.transform.position, 0.3f);
            joint5DefaultPos = Vector3.Slerp(joint5DefaultPos, joint5_OriginPos.transform.position, 0.2f);
            joint6DefaultPos = Vector3.Slerp(joint6DefaultPos, joint6_OriginPos.transform.position, 0.1f);

            blackhole.transform.rotation *= Quaternion.Euler(0f, 1f, 0f);
            /* foreach (GameObject star in stars)
            {
                // ??????? ???? ??©£? ????? ???????.
                float dis = Vector3.Distance(this.transform.position, star.transform.position);
                Debug.Log(dis);

                // 1??? ?????? ??(= ??????? ??????? 1??? ?????? ??)
                if (time > 1)
                {
                    // ?????¥ê??? ??????? ????? ?????? ?????.
                    dir = blackhole.transform.position - star.transform.position;
                    // ???? ????? ??????? ???????? ???? ????????.
                    star.transform.position += dir * 1f * Time.deltaTime;
                }
                // ??????? ???? ????? 0.3f????? ???
                //if (dis <= 0.3f)
                if (dis >= 2.5f)
                {
                    // ???? ??????? ???? ?? ?????? ????????.
                    star.transform.position += dir * 3f * Time.deltaTime;
                }
                // ??????? ???? ????? 0.05f ????? ???
                //if (dis <= 0.05f)
                if (dis < 2.5f)
                {
                    // ???? ??????? ?? ?????? ????????.
                    star.transform.position += dir * 5f * Time.deltaTime;
                    // ???? ??? ????????? 0.9?? ??????? ?????.
                    star.transform.localScale *= 0.9f;
                }
            } */
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (fuckU)
        {
            foreach (GameObject star in stars)
            {
                if (other.gameObject == star.gameObject)
                {

                    if (isCheckEnd == false)
                    {
                        NearestJointCheck(other.gameObject);
                    }
                    
                    star.GetComponent<MeshCollider>().isTrigger = true;

                    star.GetComponent<VacSlimeTest>().rootSlime.GetComponent<SlimeBase>().currentActionState = SlimeBase.ActionState.VacuumTarget;
                    // ??????? ???? ??©£? ????? ???????.

                    float dis = Vector3.Distance(this.transform.position, star.transform.position);

                    Vector3 defaultScale = star.GetComponent<VacSlimeTest>().rootSlime.transform.localScale;


                    // 1??? ?????? ??(= ??????? ??????? 1??? ?????? ??)
                    if (time > 1)
                    {
                        // ?????¥ê??? ??????? ????? ?????? ?????.
                        dir = jointArray[nearestIndex].transform.position - star.GetComponent<VacSlimeTest>().rootSlime.transform.position;
                        // ???? ????? ??????? ???????? ???? ????????.
                        star.GetComponent<VacSlimeTest>().rootSlime.transform.position += dir * 1f * Time.deltaTime;
                    }
                    //star.GetComponent<VacSlimeTest>().rootSlime.transform.position += dir * 10f * Time.deltaTime;
                    star.GetComponent<VacSlimeTest>().rootSlime.GetComponent<Rigidbody>().velocity = dir * 10f;

                    Debug.Log(Vector3.Distance(jointArray[nearestIndex].transform.position, star.GetComponent<VacSlimeTest>().rootSlime.transform.position));
                    if (Vector3.Distance(jointArray[nearestIndex].transform.position, star.GetComponent<VacSlimeTest>().rootSlime.transform.position) < 0.1f && nearestIndex > 0)
                    {
                        nearestIndex--;
                    }

                    if (nearestIndex == 1)
                    {
                        star.GetComponent<VacSlimeTest>().rootSlime.transform.localScale *= 0.9f;
                        if (star.GetComponent<VacSlimeTest>().rootSlime.transform.localScale.x < 0.5f)
                        {
                            star.GetComponent<VacSlimeTest>().rootSlime.SetActive(false);
                            Debug.Log("Èí¼ö!");
                            //nearestIndex = 0;
                        }
                    }

                    /* if (star.GetComponent<VacSlimeTest>().rootSlime.transform.localScale.x / defaultScale.x <= 0.3f)
                    {
                        star.GetComponent<VacSlimeTest>().rootSlime.SetActive(false);
                        Debug.Log("Èí¼ö!");
                    } */

                    /* if (nearestIndex == 0)
                    {
                        star.GetComponent<VacSlimeTest>().rootSlime.transform.localScale *= 0.9f;
                    } */

                    // ??????? ???? ????? 0.3f????? ???
                    //if (dis <= 0.3f)
                    /* if (dis >= 2.5f)
                    {
                        // ???? ??????? ???? ?? ?????? ????????.
                        star.GetComponent<VacSlimeTest>().rootSlime.transform.position += dir * 1f * Time.deltaTime;
                    }
                    // ??????? ???? ????? 0.05f ????? ???
                    //if (dis <= 0.05f)
                    if (dis < 2.5f)
                    {
                        // ???? ??????? ?? ?????? ????????.
                        star.GetComponent<VacSlimeTest>().rootSlime.transform.position += dir * 1.5f * Time.deltaTime;
                        // ???? ??? ????????? 0.9?? ??????? ?????.
                        //star.GetComponent<VacSlimeTest>().rootSlime.transform.localScale *= 0.9f;
                    } */
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        foreach (GameObject star in stars)
        {
            if (other.gameObject == star.gameObject)
            {
                star.GetComponent<SlimeBase>().currentActionState = SlimeBase.ActionState.Idle;
            }
        }
    }
    public int nearestIndex;
    bool isCheckEnd;

    void NearestJointCheck(GameObject obj_)
    {
        float nearestDis_ = default;
        for (int i = 0; i < jointArray.Length; i++)
        {
            float getDis_;
            getDis_ = Vector3.Distance(obj_.transform.position, jointArray[i].transform.position);
            if (nearestDis_ == default | nearestDis_ > getDis_)
            {
                nearestDis_ = getDis_;
                nearestIndex = i;
            }

            if (i == jointArray.Length - 1)
            {
                isCheckEnd = true;
            }
        }
    }
}

