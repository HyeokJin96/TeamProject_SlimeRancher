using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : GSingleton<InventoryManager>
{
    public GameObject[] quickSlotObject = new GameObject[4];
    public int[] quickSlotCount = new int[4];


    public List<GameObject> quickSlot1 = new List<GameObject>();
    public List<GameObject> quickSlot2 = new List<GameObject>();
    public List<GameObject> quickSlot3 = new List<GameObject>();
    public List<GameObject> quickSlot4 = new List<GameObject>();
    public List<GameObject>[] quickSlotArray = new List<GameObject>[4];

    public GameObject quickSlot1_;
    public GameObject quickSlot2_;
    public GameObject quickSlot3_;
    public GameObject quickSlot4_;
    public GameObject[] quickSlot = new GameObject[4];

    public string slot1_ObjName;
    public Sprite slot1_Obj_Sprite;
    public string slot2_ObjName;
    public Sprite slot2_Obj_Sprite;
    public string slot3_ObjName;
    public Sprite slot3_Obj_Sprite;
    public string slot4_ObjName;
    public Sprite slot4_Obj_Sprite;



    public override void Awake()
    {
        base.Awake();
        quickSlotArray[0] = quickSlot1;
        quickSlotArray[1] = quickSlot2;
        quickSlotArray[2] = quickSlot3;
        quickSlotArray[3] = quickSlot4;

        quickSlot[0] = quickSlot1_;
        quickSlot[1] = quickSlot2_;
        quickSlot[2] = quickSlot3_;
        quickSlot[3] = quickSlot4_;

    }

    public bool isQuickSlotEmpty = true;

    public int QuickSlotCheck(GameObject obj_)
    {
        int index_ = FindObjectIndex(obj_);
        Debug.Log("point3 &" + index_);

        //퀵슬롯에 해당 오브젝트 존재할 경우
        if (index_ != -1)
        {
            Debug.Log("point1");
            return index_;
        }

        //퀵슬롯에 해당 오브젝트 존재하지 않을 경우
        else
        {
            for (int i = 0; i < quickSlotObject.Length; i++)
            {
                if (quickSlotObject[i] == null)
                {
                    Debug.Log("point2");
                    return i;
                }
            }
        }
        return -1;
    }

    public int FindObjectIndex(GameObject obj_)
    {
        for (int i = 0; i < quickSlotObject.Length; i++)
        {
            if (obj_.tag == "Normal Slime")
            {
                if (quickSlotObject[i] != null && quickSlotObject[i].tag == "Normal Slime" && quickSlotObject[i].GetComponent<SlimeBase>().slimeName == obj_.GetComponent<SlimeBase>().slimeName)
                {
                    return i;
                }
            }

            if (obj_.tag == "Plort")
            {
                if (quickSlotObject[i] != null && quickSlotObject[i].tag == "Plort" && quickSlotObject[i].GetComponent<PlortBase>().plortType == obj_.GetComponent<PlortBase>().plortType)
                {
                    return i;
                }
            }

            if (quickSlotObject[i] == obj_)
            {
                {
                    return i;
                }
            }
        }
        return -1;
    }
}
