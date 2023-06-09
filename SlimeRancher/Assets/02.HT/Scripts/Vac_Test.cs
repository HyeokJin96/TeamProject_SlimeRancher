using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vac_Test : MonoBehaviour
{
    public GameObject blackhole;

    GameObject[] stars;

    float time;

    Vector3 dir;

    public bool isVacuumOn;

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
    public GameObject defaultFoodPool;
    public GameObject defaultPlortPool;
    public GameObject fireDirTarget;
    public GameObject inventory;
    GameObject firedObj_;

    bool isPickUpLargo;
    GameObject pickupLargoSlime;
    MeshCollider pickupLargoCollider;

    test_veggie test_Veggie;
    private void Start()
    {
        blackhole.SetActive(false);

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

        //obj_.transform.rotation = Quaternion.identity;
        if (obj_.tag == "Normal Slime")
        {
            obj_.transform.SetParent(defaultSlimePool.transform);
            obj_.transform.rotation = Quaternion.identity;
            obj_.transform.localScale = new Vector3(2, 2, 2);

        }
        else if (obj_.tag == "Food")
        {
            obj_.transform.SetParent(defaultFoodPool.transform);
            obj_.transform.rotation = Quaternion.identity;
            obj_.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);

        }
        else
        {
            obj_.transform.SetParent(defaultPlortPool.transform);
            obj_.transform.rotation = Quaternion.identity;
            obj_.transform.localScale = Vector3.one;
        }

        obj_.SetActive(true);
        Vector3 fireDir_ = (fireDirTarget.transform.position - inventory.transform.position).normalized;
        obj_.GetComponent<Rigidbody>().AddForce(fireDir_ * 50, ForceMode.Impulse);

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
        if (isPickUpLargo)
        {
            isPickUpLargo = false;
            pickupLargoSlime.transform.SetParent(defaultSlimePool.transform);
            pickupLargoSlime.transform.rotation = Quaternion.identity;
            pickupLargoSlime.transform.localScale = new Vector3(3, 3, 3);

            Vector3 fireDir_ = (fireDirTarget.transform.position - inventory.transform.position).normalized;
            pickupLargoSlime.GetComponent<Rigidbody>().AddForce(fireDir_ * 50, ForceMode.Impulse);

            pickupLargoSlime.GetComponent<SlimeBase>().isPickup = false;
            pickupLargoCollider.isTrigger = false;
        }
        else if (!fireDelayEnd && InventoryManager.Instance.quickSlotArray[selctedSlotNumber].Count != 0)
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
        if (isPickUpLargo)
        {
            blackhole.SetActive(false);

            pickupLargoSlime.transform.position = jointArray[1].transform.position;
            pickupLargoSlime.GetComponent<SlimeBase>().isPickup = true;
            pickupLargoCollider.isTrigger = true;
        }

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

        if (Input.GetMouseButtonDown(0))
        {
            if(!UIManager.Instance.hasUiOpen)
            {
                isLeftClick_ = true;
            }

        }
        else if (Input.GetMouseButtonUp(0))
        {
            isLeftClick_ = false;
            StopCoroutine(FireDelay());
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (!UIManager.Instance.hasUiOpen)
            {
                blackhole.SetActive(true);

                joint2DefaultPos = joint2.transform.position;
                joint3DefaultPos = joint3.transform.position;
                joint4DefaultPos = joint4.transform.position;
                joint5DefaultPos = joint5.transform.position;
                joint6DefaultPos = joint6.transform.position;
                isVacuumOn = true;
            }
        }
        else if (Input.GetMouseButtonUp(1))
        {
            blackhole.SetActive(false);
            isVacuumOn = false;
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

            joint2DefaultPos = joint2_OriginPos.transform.position;
            joint3DefaultPos = joint3_OriginPos.transform.position;
            joint4DefaultPos = joint4_OriginPos.transform.position;
            joint5DefaultPos = joint5_OriginPos.transform.position;
            joint6DefaultPos = joint6_OriginPos.transform.position;

            joint2.transform.position = joint2_OriginPos.transform.position;
            joint3.transform.position = joint3_OriginPos.transform.position;
            joint4.transform.position = joint4_OriginPos.transform.position;
            joint5.transform.position = joint5_OriginPos.transform.position;
            joint6.transform.position = joint6_OriginPos.transform.position;
        }

        time += Time.deltaTime;

        if (isVacuumOn)
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
        }
    }

    public List<GameObject> eeee = new List<GameObject>();

    private void OnTriggerStay(Collider other)
    {
        if (isVacuumOn && !isPickUpLargo && other.GetType() == typeof(MeshCollider))
        {
            if (eeee.Contains(other.gameObject))
            {
                other.GetComponent<VacSlimeTest>().rootSlime.GetComponent<Rigidbody>().AddForce(inventory.transform.up * 10, ForceMode.Impulse);
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

                
                if (other.GetType() == typeof(MeshCollider))
                {
                    other.GetComponent<MeshCollider>().isTrigger = true;
                }

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
                    //Debug.Log(Vector3.Distance(jointArray[nearestIndex].transform.position, other.GetComponent<VacSlimeTest>().rootSlime.transform.position));

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
                        if (other.GetComponent<VacSlimeTest>().rootSlime.GetComponent<SlimeBase>().slimeSize == 0)
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
                        else if (other.GetComponent<VacSlimeTest>().rootSlime.GetComponent<SlimeBase>().slimeSize == 1 || other.GetComponent<VacSlimeTest>().rootSlime.GetComponent<SlimeBase>().isTarrSlime)
                        {
                            isPickUpLargo = true;
                            pickupLargoSlime = other.GetComponent<VacSlimeTest>().rootSlime;
                            pickupLargoCollider = other.GetComponent<MeshCollider>();
                            Debug.Log("largopickup");
                        }
                    }
                }

                //savepoint

                else if (other.tag == "Food" && vacuumedList.Contains(other.gameObject))
                {
                    dir = jointArray[nearestIndex].transform.position - other.transform.parent.position;
                    other.transform.parent.GetComponent<Rigidbody>().velocity = dir * 10f;

                    // 대상 오브젝트와 joint 간의 거리가 0.1f보다 작아지면 다음 joint로 변경
                    if (Vector3.Distance(jointArray[nearestIndex].transform.position, other.transform.parent.position) < 0.1f && nearestIndex > 0)
                    {
                        nearestIndex--;
                    }

                    if (nearestIndex == 1)
                    {
                        //if() : quick slot에 빈 칸이 있으면 scale을 축소, else : 빈칸이 없으면 축소하지 않음
                        int quickSlotCheck_ = InventoryManager.Instance.QuickSlotCheck(other.transform.parent.gameObject);
                        if (quickSlotCheck_ != -1)
                        {
                            other.transform.parent.localScale *= 0.9f;
                        }

                        // 대상 오브젝트의 scale이 0.5보다 작아지면 'quickslot'으로 이동, 해당 오브젝트 off
                        if (other.transform.parent.localScale.x < 0.15f)
                        {
                            InventoryManager.Instance.quickSlotObject[quickSlotCheck_] = other.transform.parent.gameObject;
                            InventoryManager.Instance.quickSlotArray[quickSlotCheck_].Add(other.transform.parent.gameObject);


                            if (quickSlotCheck_ == 0)
                            {
                                InventoryManager.Instance.slot1_ObjName = other.transform.parent.GetComponent<ObjecData>().foodName.ToString();
                                InventoryManager.Instance.slot1_Obj_Sprite = other.transform.parent.GetComponent<ObjecData>().foodIcon;
                            }
                            else if (quickSlotCheck_ == 1)
                            {
                                InventoryManager.Instance.slot2_ObjName = other.transform.parent.GetComponent<ObjecData>().foodName.ToString();
                                InventoryManager.Instance.slot2_Obj_Sprite = other.transform.parent.GetComponent<ObjecData>().foodIcon;
                            }
                            else if (quickSlotCheck_ == 2)
                            {
                                InventoryManager.Instance.slot3_ObjName = other.transform.parent.GetComponent<ObjecData>().foodName.ToString();
                                InventoryManager.Instance.slot3_Obj_Sprite = other.transform.parent.GetComponent<ObjecData>().foodIcon;
                            }
                            else if (quickSlotCheck_ == 3)
                            {
                                InventoryManager.Instance.slot4_ObjName = other.transform.parent.GetComponent<ObjecData>().foodName.ToString();
                                InventoryManager.Instance.slot4_Obj_Sprite = other.transform.parent.GetComponent<ObjecData>().foodIcon;
                            }


                            InventoryManager.Instance.quickSlotCount[quickSlotCheck_]++;

                            other.transform.parent.SetParent(InventoryManager.Instance.quickSlot[quickSlotCheck_].transform);
                            other.transform.parent.rotation = Quaternion.identity;
                            other.transform.parent.gameObject.SetActive(false);

                            //nearestIndex = 0;
                        }
                    }
                }


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

                        }
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetType() == typeof(MeshCollider))
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

