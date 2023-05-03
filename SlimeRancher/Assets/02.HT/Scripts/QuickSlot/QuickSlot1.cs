using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuickSlot1 : QuickSlotBase
{
    public GameObject slotIcon;
    TMP_Text objName;
    TMP_Text objCount;

    GameObject quickSlotBg;


    // Start is called before the first frame update
    void Start()
    {
        slotIcon = transform.GetChild(3).gameObject;
        objName = transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>();
        objCount = transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>();
        quickSlotBg = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        slotObjCount = InventoryManager.Instance.quickSlotCount[0];

        if (slotObjCount != 0)
        {
            slotIcon.SetActive(true);
            quickSlotBg.GetComponent<Image>().sprite = quickSlotBg2;

            slotObjName = InventoryManager.Instance.slot1_ObjName;
            slotSprite = InventoryManager.Instance.slot1_Obj_Sprite;

            slotIcon.GetComponent<Image>().sprite = slotSprite;
            slotIcon.GetComponent<Image>().SetNativeSize();


            objName.enabled = true;
            objCount.enabled = true;

            objName.text = slotObjName;
            objCount.text = $"X {slotObjCount}";

        }
        else
        {
            slotIcon.SetActive(false);
            quickSlotBg.GetComponent<Image>().sprite = quickSlotBg1;

            slotObjName = null;
            slotSprite = null;
            slotIcon.GetComponent<Image>().sprite = slotSprite;


            objName.enabled = false;
            objCount.enabled = false;
        }
    }
}
