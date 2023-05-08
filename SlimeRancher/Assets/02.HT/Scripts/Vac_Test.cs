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
    public List<GameObject> vacuumedList;

    public int selctedSlotNumber = default;

    public GameObject muzzle;

    public GameObject defaultSlimePool;
    public GameObject fireDirTarget;
    public GameObject inventory;
    GameObject firedObj_;

    private void Start()
    {
        blackhole.SetActive(false);

        // "Star"?? ?��?? ?????? ???????????? ???? Star ?��?? ??��?.
        //stars = GameObject.FindGameObjectsWithTag("Star");
        stars = GameObject.FindGameObjectsWithTag("Normal Slime");

        jointArray = new GameObject[] { joint1, joint2, joint3, joint4, joint5, joint6 };
        vacuumedList = new List<GameObject>();
    }

    void FireObject(GameObject obj_)
    {
        InventoryManager.Instance.quickSlotArray[selctedSlotNumber].Remove(obj_);
        InventoryManager.Instance.quickSlotCount[selctedSlotNumber]--;

        if (InventoryManager.Instance.quickSlotCount[selctedSlotNumber] == 0)
        {
            InventoryManager.Instance.quickSlotObject[selctedSlotNumber] = null;
        }

        obj_.transform.SetParent(defaultSlimePool.transform);
        obj_.transform.rotation = Quaternion.identity;
        if (obj_.tag == "Normal Slime")
        {
            obj_.transform.localScale = new Vector3(2, 2, 2);

        }
        else
        {
            obj_.transform.localScale = Vector3.one;
        }

        obj_.SetActive(true);
        Vector3 fireDir_ = (fireDirTarget.transform.position - inventory.transform.position).normalized;
        obj_.GetComponent<Rigidbody>().AddForce(fireDir_ * 50, ForceMode.Impulse);

        /* if (InventoryManager.Instance.quickSlotArray[selctedSlotNumber].Count != 0)
        {
            firedObj_ = InventoryManager.Instance.quickSlot[selctedSlotNumber].transform.GetChild(0).gameObject;
        } */
    }
    public bool fireDelayEnd;

    IEnumerator FireDelay()
    {
        Fire();
        fireDelayEnd = true;
        yield return new WaitForSeconds(0.5f);
        fireDelayEnd = false;
    }

    void Fire()
    {
        if (!fireDelayEnd && InventoryManager.Instance.quickSlotArray[selctedSlotNumber].Count != 0)
        {
            switch (selctedSlotNumber)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    firedObj_ = (InventoryManager.Instance.quickSlotArray[selctedSlotNumber])[0];
                    break;
            }
            FireObject(firedObj_);
        }
    }
    public bool isLeftClick_;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selctedSlotNumber = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selctedSlotNumber = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selctedSlotNumber = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selctedSlotNumber = 3;
        }

        /* if (isFire)
        {
            StartCoroutine(FireDelay());
        } */
        if (Input.GetMouseButton(0))
        {
            if (isLeftClick_)
            {
                if (fireDelayEnd == false)
                {
                    StartCoroutine(FireDelay());
                }
            }
        }

        /* if (!fireDelayEnd)
        {
            if (InventoryManager.Instance.quickSlotArray[selctedSlotNumber].Count != 0)
            {
                switch (selctedSlotNumber)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                        firedObj_ = (InventoryManager.Instance.quickSlotArray[selctedSlotNumber])[0];
                        break;
                }
                FireObject(firedObj_);
            }
        } */


        if (Input.GetMouseButtonDown(0))
        {
            isLeftClick_ = true;

            //blackhole.SetActive(true);
            //GameObject firedObj_;

            // if (InventoryManager.Instance.quickSlotArray[selctedSlotNumber].Count == 0)
            // {
            //     Debug.Log("null");
            // }
            // else
            // {
            //     switch (selctedSlotNumber)
            //     {
            //         case 0:
            //             firedObj_ = InventoryManager.Instance.quickSlot[selctedSlotNumber].transform.GetChild(0).gameObject;
            //             //FireObject(firedObj_);
            //             /* firedObj_.transform.SetParent(defaultSlimePool.transform);
            //             firedObj_.transform.localScale = Vector3.one;
            //             firedObj_.SetActive(true);
            //             Vector3 fireDir_ = -(fireDirTarget.transform.position - firedObj_.transform.position).normalized;
            //             firedObj_.GetComponent<Rigidbody>().AddForce(fireDir_ * 50, ForceMode.Impulse); */

            //             //[0503]
            //             //InventoryManager.Instance.quickSlot1_.transform.GetChild(0).gameObject.SetActive(true);
            //             //InventoryManager.Instance.quickSlot1_.transform.GetChild(0).gameObject.GetComponent<Rigidbody>().AddForce(muzzle.transform.up * 10, ForceMode.Impulse);
            //             break;
            //         case 1:
            //             firedObj_ = InventoryManager.Instance.quickSlot[selctedSlotNumber].transform.GetChild(0).gameObject;
            //             //FireObject(firedObj_);
            //             break;
            //         case 2:
            //             firedObj_ = InventoryManager.Instance.quickSlot[selctedSlotNumber].transform.GetChild(0).gameObject;
            //             //FireObject(firedObj_);
            //             break;
            //         case 3:
            //             firedObj_ = InventoryManager.Instance.quickSlot[selctedSlotNumber].transform.GetChild(0).gameObject;
            //             //FireObject(firedObj_);
            //             break;
            //     }
            //     FireObject(firedObj_);
            // }

            //while (InventoryManager.Instance.quickSlotArray[selctedSlotNumber].Count != 0)
            //{
            //    StartCoroutine(FireDelay());
            //}
            /* while (InventoryManager.Instance.quickSlotArray[selctedSlotNumber].Count != 0)
            {
                switch (selctedSlotNumber)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                        //firedObj_ = InventoryManager.Instance.quickSlot[selctedSlotNumber].transform.GetChild(0).gameObject;
                        firedObj_ = (InventoryManager.Instance.quickSlotArray[selctedSlotNumber])[objIndex];
                        break;
                }
                FireObject(firedObj_);
            }
             */








            // while (InventoryManager.Instance.quickSlotArray[selctedSlotNumber].Count != 0)
            // {
            //     switch (selctedSlotNumber)
            //     {
            //         case 0:
            //             firedObj_ = (InventoryManager.Instance.quickSlotArray[0])[0];
            //             //firedObj_ = InventoryManager.Instance.quickSlot[selctedSlotNumber].transform.GetChild(0).gameObject;

            //             //FireObject(firedObj_);
            //             /* firedObj_.transform.SetParent(defaultSlimePool.transform);
            //             firedObj_.transform.localScale = Vector3.one;
            //             firedObj_.SetActive(true);
            //             Vector3 fireDir_ = -(fireDirTarget.transform.position - firedObj_.transform.position).normalized;
            //             firedObj_.GetComponent<Rigidbody>().AddForce(fireDir_ * 50, ForceMode.Impulse); */

            //             //[0503]
            //             //InventoryManager.Instance.quickSlot1_.transform.GetChild(0).gameObject.SetActive(true);
            //             //InventoryManager.Instance.quickSlot1_.transform.GetChild(0).gameObject.GetComponent<Rigidbody>().AddForce(muzzle.transform.up * 10, ForceMode.Impulse);
            //             break;
            //         case 1:
            //             firedObj_ = InventoryManager.Instance.quickSlot[selctedSlotNumber].transform.GetChild(0).gameObject;
            //             //FireObject(firedObj_);
            //             break;
            //         case 2:
            //             firedObj_ = InventoryManager.Instance.quickSlot[selctedSlotNumber].transform.GetChild(0).gameObject;
            //             //FireObject(firedObj_);
            //             break;
            //         case 3:
            //             firedObj_ = InventoryManager.Instance.quickSlot[selctedSlotNumber].transform.GetChild(0).gameObject;
            //             //FireObject(firedObj_);
            //             break;
            //     }
            //     FireObject(firedObj_);
            // }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //blackhole.SetActive(false);
            isLeftClick_ = false;
            StopCoroutine(FireDelay());
        }

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

            int triggerCheckCount_ = 0;
            for (int i = 0; i < vacuumedList.Count; i++)
            {
                vacuumedList[i].GetComponent<MeshCollider>().isTrigger = false;
                triggerCheckCount_++;
            }
            if (triggerCheckCount_ == vacuumedList.Count)
            {
                vacuumedList.Clear();
            }
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
                // ??????? ???? ??��? ????? ???????.
                float dis = Vector3.Distance(this.transform.position, star.transform.position);
                Debug.Log(dis);

                // 1??? ?????? ??(= ??????? ??????? 1??? ?????? ??)
                if (time > 1)
                {
                    // ?????��??? ??????? ????? ?????? ?????.
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

    public List<GameObject> eeee = new List<GameObject>();

    private void OnTriggerStay(Collider other)
    {
        if (fuckU)
        {
            if (eeee.Contains(other.gameObject))
            {
                //Vector3 fireDir_ = (fireDirTarget.transform.position - inventory.transform.position).normalized;
                other.GetComponent<VacSlimeTest>().rootSlime.GetComponent<Rigidbody>().AddForce(inventory.transform.up * 10, ForceMode.Impulse);
                //eeee.Remove(other.gameObject);
            }

            if ((other.tag == "Normal Slime" || other.tag == "Food" || other.tag == "Plort") && !eeee.Contains(other.gameObject)) //slime Tag 통일(Normal Slime, Largo Slime, Tarr Slime => Slime)
            {

                // 대상 오브젝트들을 리스트에 추가
                if (!vacuumedList.Contains(other.gameObject))
                {
                    vacuumedList.Add(other.gameObject);
                }

                // 오브젝트와 가까운 조인트 체크
                if (isCheckEnd == false)
                {
                    NearestJointCheck(other.gameObject);
                }

                // 대상 오브젝트 콜라이더 트리거 on
                other.GetComponent<MeshCollider>().isTrigger = true;

                // 대상 오브젝트가 슬라임이면, state 변경
                if (other.tag == "Normal Slime")
                {
                    other.GetComponent<VacSlimeTest>().rootSlime.GetComponent<SlimeBase>().currentActionState = SlimeBase.ActionState.VacuumTarget;
                }

                // 대상 오브젝트의 시작 scale 저장
                //Vector3 defaultScale = other.GetComponent<VacSlimeTest>().rootSlime.transform.localScale;

                // 대상 오브젝트에 속력 부여
                if (other.tag == "Normal Slime" && vacuumedList.Contains(other.gameObject))
                {
                    Debug.Log(Vector3.Distance(jointArray[nearestIndex].transform.position, other.GetComponent<VacSlimeTest>().rootSlime.transform.position));
                    
                    dir = jointArray[nearestIndex].transform.position - other.GetComponent<VacSlimeTest>().rootSlime.transform.position;
                    other.GetComponent<VacSlimeTest>().rootSlime.GetComponent<Rigidbody>().velocity = dir * 10f;

                    // 대상 오브젝트와 joint 간의 거리가 0.1f보다 작아지면 다음 joint로 변경
                    if (Vector3.Distance(jointArray[nearestIndex].transform.position, other.GetComponent<VacSlimeTest>().rootSlime.transform.position) < 0.1f && nearestIndex > 0)
                    {
                        nearestIndex--;
                    }

                    // 마지막 joint로 옮겨졌을때, 대상 오브젝트의 scale 축소
                    if (nearestIndex == 1)
                    {
                        //if() : quick slot에 빈 칸이 있으면 scale을 축소, else : 빈칸이 없으면 축소하지 않음
                        int quickSlotCheck_ = InventoryManager.Instance.QuickSlotCheck(other.GetComponent<VacSlimeTest>().rootSlime);
                        if (quickSlotCheck_ != -1)
                        {
                            other.GetComponent<VacSlimeTest>().rootSlime.transform.localScale *= 0.9f;
                        }
                        else
                        {
                            other.GetComponent<VacSlimeTest>().rootSlime.transform.localScale = new Vector3(2, 2, 2);
                            vacuumedList.Remove(other.gameObject);
                            if (!eeee.Contains(other.gameObject))
                            {
                                eeee.Add(other.gameObject);
                            }
                        }


                        // 대상 오브젝트의 scale이 0.5보다 작아지면 'quickslot'으로 이동, 해당 오브젝트 off
                        if (other.GetComponent<VacSlimeTest>().rootSlime.transform.localScale.x < 0.5f)
                        {
                            InventoryManager.Instance.quickSlotObject[quickSlotCheck_] = other.GetComponent<VacSlimeTest>().rootSlime;
                            InventoryManager.Instance.quickSlotArray[quickSlotCheck_].Add(other.GetComponent<VacSlimeTest>().rootSlime);

                            if (quickSlotCheck_ == 0)
                            {
                                InventoryManager.Instance.slot1_ObjName = other.GetComponent<VacSlimeTest>().rootSlime.GetComponent<SlimeBase>().slimeName;
                                InventoryManager.Instance.slot1_Obj_Sprite = other.GetComponent<VacSlimeTest>().rootSlime.GetComponent<SlimeBase>().slimeIcon;
                            }
                            else if (quickSlotCheck_ == 1)
                            {
                                InventoryManager.Instance.slot2_ObjName = other.GetComponent<VacSlimeTest>().rootSlime.GetComponent<SlimeBase>().slimeName;
                                InventoryManager.Instance.slot2_Obj_Sprite = other.GetComponent<VacSlimeTest>().rootSlime.GetComponent<SlimeBase>().slimeIcon;
                            }
                            else if (quickSlotCheck_ == 2)
                            {
                                InventoryManager.Instance.slot3_ObjName = other.GetComponent<VacSlimeTest>().rootSlime.GetComponent<SlimeBase>().slimeName;
                                InventoryManager.Instance.slot3_Obj_Sprite = other.GetComponent<VacSlimeTest>().rootSlime.GetComponent<SlimeBase>().slimeIcon;
                            }
                            else if (quickSlotCheck_ == 3)
                            {
                                InventoryManager.Instance.slot4_ObjName = other.GetComponent<VacSlimeTest>().rootSlime.GetComponent<SlimeBase>().slimeName;
                                InventoryManager.Instance.slot4_Obj_Sprite = other.GetComponent<VacSlimeTest>().rootSlime.GetComponent<SlimeBase>().slimeIcon;
                            }


                            InventoryManager.Instance.quickSlotCount[quickSlotCheck_]++;

                            other.GetComponent<VacSlimeTest>().rootSlime.transform.SetParent(InventoryManager.Instance.quickSlot[quickSlotCheck_].transform);
                            other.GetComponent<VacSlimeTest>().rootSlime.transform.rotation = Quaternion.identity;
                            other.GetComponent<VacSlimeTest>().rootSlime.SetActive(false);
                            //nearestIndex = 0;
                        }
                    }
                }

                //savepoint

                else
                {
                    dir = jointArray[nearestIndex].transform.position - other.transform.position;
                    other.GetComponent<Rigidbody>().velocity = dir * 10f;

                    // 대상 오브젝트와 joint 간의 거리가 0.1f보다 작아지면 다음 joint로 변경
                    if (Vector3.Distance(jointArray[nearestIndex].transform.position, other.transform.position) < 0.1f && nearestIndex > 0)
                    {
                        nearestIndex--;
                    }

                    if (nearestIndex == 1)
                    {
                        //if() : quick slot에 빈 칸이 있으면 scale을 축소, else : 빈칸이 없으면 축소하지 않음
                        int quickSlotCheck_ = InventoryManager.Instance.QuickSlotCheck(other.gameObject);
                        if (quickSlotCheck_ != -1)
                        {
                            other.transform.localScale *= 0.9f;
                        }

                        // 대상 오브젝트의 scale이 0.5보다 작아지면 'quickslot'으로 이동, 해당 오브젝트 off
                        if (other.transform.localScale.x < 0.5f)
                        {
                            InventoryManager.Instance.quickSlotObject[quickSlotCheck_] = other.gameObject;
                            InventoryManager.Instance.quickSlotArray[quickSlotCheck_].Add(other.gameObject);


                            if (quickSlotCheck_ == 0)
                            {
                                InventoryManager.Instance.slot1_ObjName = other.GetComponent<PlortBase>().plortName[other.GetComponent<PlortBase>().plortType];
                                InventoryManager.Instance.slot1_Obj_Sprite = other.GetComponent<PlortBase>().plortIcon[other.GetComponent<PlortBase>().plortType];
                            }
                            else if (quickSlotCheck_ == 1)
                            {
                                InventoryManager.Instance.slot2_ObjName = other.GetComponent<PlortBase>().plortName[other.GetComponent<PlortBase>().plortType];
                                InventoryManager.Instance.slot2_Obj_Sprite = other.GetComponent<PlortBase>().plortIcon[other.GetComponent<PlortBase>().plortType];
                            }
                            else if (quickSlotCheck_ == 2)
                            {
                                InventoryManager.Instance.slot3_ObjName = other.GetComponent<PlortBase>().plortName[other.GetComponent<PlortBase>().plortType];
                                InventoryManager.Instance.slot3_Obj_Sprite = other.GetComponent<PlortBase>().plortIcon[other.GetComponent<PlortBase>().plortType];
                            }
                            else if (quickSlotCheck_ == 3)
                            {
                                InventoryManager.Instance.slot4_ObjName = other.GetComponent<PlortBase>().plortName[other.GetComponent<PlortBase>().plortType];
                                InventoryManager.Instance.slot4_Obj_Sprite = other.GetComponent<PlortBase>().plortIcon[other.GetComponent<PlortBase>().plortType];
                            }


                            InventoryManager.Instance.quickSlotCount[quickSlotCheck_]++;

                            other.transform.SetParent(InventoryManager.Instance.quickSlot[quickSlotCheck_].transform);
                            other.transform.rotation = Quaternion.identity;
                            other.gameObject.SetActive(false);

                            //nearestIndex = 0;
                        }
                    }
                }


            }




            // foreach (GameObject star in stars)
            // {
            //     if (other.gameObject == star.gameObject)
            //     {
            //         if (!vacuumedList.Contains(other.gameObject))
            //         {
            //             vacuumedList.Add(other.gameObject);
            //         }



            //         if (isCheckEnd == false)
            //         {
            //             NearestJointCheck(other.gameObject);
            //         }

            //         star.GetComponent<MeshCollider>().isTrigger = true;

            //         star.GetComponent<VacSlimeTest>().rootSlime.GetComponent<SlimeBase>().currentActionState = SlimeBase.ActionState.VacuumTarget;
            //         // ??????? ???? ??��? ????? ???????.

            //         float dis = Vector3.Distance(this.transform.position, star.transform.position);

            //         Vector3 defaultScale = star.GetComponent<VacSlimeTest>().rootSlime.transform.localScale;


            //         // 1??? ?????? ??(= ??????? ??????? 1??? ?????? ??)
            //         if (time > 1)
            //         {
            //             // ?????��??? ??????? ????? ?????? ?????.
            //             dir = jointArray[nearestIndex].transform.position - star.GetComponent<VacSlimeTest>().rootSlime.transform.position;
            //             // ???? ????? ??????? ???????? ???? ????????.
            //             star.GetComponent<VacSlimeTest>().rootSlime.transform.position += dir * 1f * Time.deltaTime;
            //         }
            //         //star.GetComponent<VacSlimeTest>().rootSlime.transform.position += dir * 10f * Time.deltaTime;
            //         star.GetComponent<VacSlimeTest>().rootSlime.GetComponent<Rigidbody>().velocity = dir * 10f;

            //         if (Vector3.Distance(jointArray[nearestIndex].transform.position, star.GetComponent<VacSlimeTest>().rootSlime.transform.position) < 0.1f && nearestIndex > 0)
            //         {
            //             nearestIndex--;
            //         }

            //         if (nearestIndex == 1)
            //         {
            //             star.GetComponent<VacSlimeTest>().rootSlime.transform.localScale *= 0.9f;
            //             if (star.GetComponent<VacSlimeTest>().rootSlime.transform.localScale.x < 0.5f)
            //             {
            //                 star.GetComponent<VacSlimeTest>().rootSlime.SetActive(false);
            //                 //nearestIndex = 0;
            //             }
            //         }

            //         /* if (star.GetComponent<VacSlimeTest>().rootSlime.transform.localScale.x / defaultScale.x <= 0.3f)
            //         {
            //             star.GetComponent<VacSlimeTest>().rootSlime.SetActive(false);
            //             Debug.Log("����!");
            //         } */

            //         /* if (nearestIndex == 0)
            //         {
            //             star.GetComponent<VacSlimeTest>().rootSlime.transform.localScale *= 0.9f;
            //         } */

            //         // ??????? ???? ????? 0.3f????? ???
            //         //if (dis <= 0.3f)
            //         /* if (dis >= 2.5f)
            //         {
            //             // ???? ??????? ???? ?? ?????? ????????.
            //             star.GetComponent<VacSlimeTest>().rootSlime.transform.position += dir * 1f * Time.deltaTime;
            //         }
            //         // ??????? ???? ????? 0.05f ????? ???
            //         //if (dis <= 0.05f)
            //         if (dis < 2.5f)
            //         {
            //             // ???? ??????? ?? ?????? ????????.
            //             star.GetComponent<VacSlimeTest>().rootSlime.transform.position += dir * 1.5f * Time.deltaTime;
            //             // ???? ??? ????????? 0.9?? ??????? ?????.
            //             //star.GetComponent<VacSlimeTest>().rootSlime.transform.localScale *= 0.9f;
            //         } */
            //     }
            // }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Normal Slime")
        {
            other.GetComponent<VacSlimeTest>().rootSlime.GetComponent<SlimeBase>().currentActionState = SlimeBase.ActionState.Idle;

            other.GetComponent<VacSlimeTest>().rootSlime.transform.localScale = new Vector3(2, 2, 2);

            other.GetComponent<MeshCollider>().isTrigger = false;
        }
        else if (other.tag == "Food" || other.tag == "Plort")
        {
            other.GetComponent<MeshCollider>().isTrigger = false;
        }
        vacuumedList.Remove(other.gameObject);
        /* 
                foreach (GameObject star in stars)
                {
                    if (other.gameObject == star.gameObject)
                    {
                        star.GetComponent<SlimeBase>().currentActionState = SlimeBase.ActionState.Idle;
                    }
                }
         */
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

