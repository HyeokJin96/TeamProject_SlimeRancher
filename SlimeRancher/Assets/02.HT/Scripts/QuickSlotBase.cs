using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSlotBase : MonoBehaviour
{
    public string slotObjName;
    public int slotObjCount;
    public Sprite slotSprite;

    public Sprite quickSlotBg1;
    public Sprite quickSlotBg2;

    private void Awake()
    {
        quickSlotBg1 = Resources.Load<Sprite>("02.HT/QuickSlot/QuickSlotBg1");
        quickSlotBg2 = Resources.Load<Sprite>("02.HT/QuickSlot/QuickSlotBg2");
    }

}
